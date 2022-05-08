using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Softtech.Data;
using Softtech.Models;
using Softtech.Repositories;
using Softtech.Services;
using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    public class InspectionsController : BaseController
    {
        private readonly ResManagementDBContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IInspectionRepository repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InspectionsController(ResManagementDBContext context, UserManager<ApplicationUser> userManager, IInspectionRepository repository, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.userManager = userManager;
            this.repository = repository;
            _webHostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult ViewDetails(string id)
        {
            var app = context.TblBookings.Find(id);

            return View(app);
        }
        public ViewResult GetAllInspectionToList()
        {
            var data = context.TblInspections.Include(s => s.Student).Include(r => r.Room).AsTracking();
           
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> SignedDoc(string id = null)
        {
            if (id == null)
            {
                PopulateRoomDropDownList();
                return View(new InspectionViewModel());
            }
            else
            {
                PopulateRoomDropDownList();
                var inspec = await context.TblInspections.FindAsync(id);
                if (inspec == null)
                {
                    return NotFound();
                }
                return View(inspec);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignedDoc(string id, InspectionViewModel model)
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            PopulateRoomDropDownList();
            if (ModelState.IsValid)
            {
                PopulateRoomDropDownList();
                var inspection = context.TblInspections.Find(id);

                if (id == null)
                {
                    try
                    {
                        if (model.CheckPdf != null)
                        {
                            string folder = "checklist/pdf/";
                            model.CheckPdfUrl = await UploadImage(folder, model.CheckPdf);
                        }
                        if (model.StudentId == null)
                        {
                            model.StudentId = currentUser.Id;
                        }
                        PopulateRoomDropDownList(model.RoomId);
                        await repository.AddNew(model);
                        Notify("Your inspection info was uploaded successfully");
                    }
                    catch (Exception)
                    {
                        Notify("Something went wrong please you provided all necessary info", notificationType: NotificationType.error);
                        return View();
                    }
                }
                else
                {
                    try
                    {
                        model.Date = inspection.Date;
                        model.Comment = inspection.Comment;
                        model.StudentId = inspection.StudentId;

                        PopulateRoomDropDownList(model.InspectionId);
                        context.Update(model);
                        await context.SaveChangesAsync();
                        Notify("Your notes inspection was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(model.InspectionId))
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
            return context.TblInspections.Any(e => e.InspectionId == id);
        }

        public IActionResult Delete(string Id)
        {
            TblInspection inspection = context.TblInspections.Find(Id);
            if (inspection != null)
            {
                context.TblInspections.Remove(inspection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(inspection);
        }
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
        private void PopulateRoomDropDownList(object selectedRoom = null)
        {
            var roomQuery = from d in context.TblRooms
                            orderby d.RoomNo
                            select d;
            ViewBag.RoomId = new SelectList(roomQuery.AsNoTracking(), "RoomId", "RoomNo",
            selectedRoom);
        }
    }
}
