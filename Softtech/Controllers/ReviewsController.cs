using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Softtech.Data;
using Softtech.Models;
using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    public class ReviewsController : BaseController
    {
        private readonly ResManagementDBContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public ReviewsController(ResManagementDBContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public ActionResult Index()
        {
            var reviews = context.TblReviews.Include(s => s.Student).AsNoTracking();
            return View(reviews);
        }
        public IActionResult Edit(ReviewViewModel model)
        {
            return View(model);
        }
        public async Task<ActionResult> Create(string id)
        {
            if (id == null)
            {
                return View(new ReviewViewModel());
            }
            else
            {
                var review = await context.TblReviews.FindAsync(id);
                if (review == null)
                {
                    return NotFound();
                }
                return View("Edit", review);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string id, ReviewViewModel model)
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                var review = context.TblReviews.Find(id);
                if (id == null)
                {
                    //try
                    //{
                        var rev = new TblReview
                        {
                            Comment = model.Comment,
                            Reply = model.Reply,
                            Rate = model.Rate,
                            StudentId = currentUser.Id
                        };
                        context.Add(rev);
                        await context.SaveChangesAsync();
                        Notify("Your comment was successfully published");
                    //}
                    //catch (Exception)
                    //{
                    //    Notify("Something went wrong please you provided all necessary info", notificationType: NotificationType.error);
                    //    return View();
                    //}
                }
                else
                {
                    try
                    {
                        model.Comment = review.Comment;
                        model.Rate = review.Rate;
                        model.StudentId = review.StudentId;
                        model.Reply = review.Reply;

                        context.Update(model);
                        await context.SaveChangesAsync();
                        Notify("Your payment has been recieved");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(model.ReviewId))
                        {
                            return NotFound();
                        }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(StudentsController.Index), "Students");
            }
            return View(model);
        }



        private bool ModelExists(string id)
        {
            return context.TblReviews.Any(e => e.ReviewId == id);
        }
    }
}
