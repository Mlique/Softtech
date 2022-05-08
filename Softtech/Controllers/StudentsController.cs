using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Softtech.Data;
using Softtech.Models;
using Softtech.Repositories;
using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    ////[Authorize(Roles = "Student")]
    public class StudentsController : BaseController
    {
        private readonly ResManagementDBContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IBookingRepository bookingRepository;
        private readonly IWebHostEnvironment hostEnvironment;

        public StudentsController(ResManagementDBContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IBookingRepository bookingRepository, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.bookingRepository = bookingRepository;
            this.hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var bookingList = context.TblBookings
                 .Include(a => a.Room)
                 .Include(r => r.RoomType)
                 .AsNoTracking();

            var currentUser = await userManager.GetUserAsync(HttpContext.User);

            var bookings = await bookingRepository.StudentBookingssAsync(currentUser.Id);
            var BookList = bookings.Select(a => new BookingListViewModel
            {
                CVV = a.CVV,
                Year = a.Year,
                Date = DateTime.Now,
                Status = a.Status,
                PayAmount = a.PayAmount,
                ExpiryYear = a.ExpiryYear,
                CardHolder = a.CardHolder,
                CardNumber = a.CardNumber,
                BursaryName = a.BursaryName,
                ExpiryMonth = a.ExpiryMonth,
                ContactNumber = a.ContactNumber,
                StudentFundedBy = a.StudentFundedBy,
                TermsAndConditions = a.TermsAndConditions,
                RoomId = a?.Room?.RoomNo ?? "<Not Assigned>",
                RoomTypeId = a?.RoomType?.Name ?? "<Not Assigned>",
                StudentId = a?.Student?.FullName ?? "<Not Transfered>"
            })
            .ToList();

            return View(BookList);
        }
        public IActionResult successStatus(string id, BookingViewModel model)
        {
            var notification = context.TblBookings.Find(id);
            if (notification != null)
            {
                notification.Status = model.Status;
            }
            return View(notification);
        }
        [HttpGet]
        public async Task<IActionResult> AllStudents()
        {
            List<ViewModelUserRole> students = new List<ViewModelUserRole>();
            var stud = await userManager.GetUsersInRoleAsync("Student");
            foreach (var st in stud)
            {
                students.Add(new ViewModelUserRole
                {
                    FirstName = st.FirstName,
                    LastName = st.LastName,
                    AddressLine1 = st.AddressLine1,
                    AddressLine2 = st.AddressLine2
                });
            }
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> EditCurrentUser()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }
            PopulateCityDropDownList();
            var model = new EditUserViewModel
            {

                City = user.City,
                Province = user.Province,
                Country = user.Country,
                LastName = user.LastName,
                Username = user.UserName,
                Email = user.Email,
                ZipCode = user.ZipCode,
                FirstName = user.FirstName,
                CellNumber = user.PhoneNumber,
                Relationship = user.Relationship,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCurrentUser(EditUserViewModel model)
        {

            string uniqueFileName = UploadedFile(model);
            PopulateCityDropDownList();
            if (!ModelState.IsValid)
            {
                Notify("All field are required", notificationType: NotificationType.warning);
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var email = user.Email;
            if (model.Email != email)
            {
                var setEmailResult = await userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

            var phoneNumber = user.PhoneNumber;
            if (model.CellNumber != phoneNumber)
            {
                var setPhoneResult = await userManager.SetPhoneNumberAsync(user, model.CellNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            user.City = model.City;
            user.LastName = model.LastName;
            user.ImagePath = uniqueFileName;
            user.FirstName = model.FirstName;
            user.AddressLine1 = model.AddressLine1;
            user.AddressLine2 = model.AddressLine2;
            user.Province = model.Province;
            user.City = model.City;
            user.Country = model.Country;
            user.ZipCode = model.ZipCode;
            user.DateOfBirth = model.DateOfBirth;

            PopulateCityDropDownList(model.City);

            await userManager.UpdateAsync(user);

            await signInManager.RefreshSignInAsync(user);
            Notify("Your profile was updated successfully");
            return RedirectToAction(nameof(StudentDetails));
        }
        [HttpGet]
        public IActionResult StudentDetails()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            if (userId == null)
            {
                return RedirectToAction(nameof(StudentsController.Index), "Students");
            }
            else
            {
                ApplicationUser user = userManager.FindByIdAsync(userId).Result;
                return View(user);
            }
           
        }
        private void PopulateCityDropDownList(object selectedCity = null)
        {
            var CityQuery = from d in context.TblCities
                            orderby d.CityName
                            select d;
            ViewBag.CityId = new SelectList(CityQuery.AsNoTracking(), "CityId", "CityName",
            selectedCity);
        }
        private string UploadedFile(EditUserViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "profileImage");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}