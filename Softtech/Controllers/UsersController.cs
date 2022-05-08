using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Softtech.Data;
using Softtech.Models;
using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    public class UsersController : BaseController
    {
        private RoleManager<ApplicationRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ResManagementDBContext context;
        private readonly IWebHostEnvironment hostEnvironment;

        public UsersController(RoleManager<ApplicationRole> roleMgr, UserManager<ApplicationUser> userMrg, SignInManager<ApplicationUser> signInManager, ResManagementDBContext context, IWebHostEnvironment hostEnvironment)
        {
            roleManager = roleMgr;
            userManager = userMrg;
            this.signInManager = signInManager;
            this.context = context;
            this.context = context;
            this.hostEnvironment = hostEnvironment;
        }
        [Authorize(Roles = "Student")]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                Notify("User can't be deleted most activities depends on", notificationType: NotificationType.error);
                return View(nameof(Index));
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("Index");
            }

        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            PopulateCityDropDownList();
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                Notify("User Not Found", notificationType: NotificationType.error);
                return View("AllStudents");
            }

            // GetClaimsAsync retunrs the list of user Claims
            var userClaims = await userManager.GetClaimsAsync(user);
            // GetRolesAsync returns the list of user Roles
            var userRoles = await userManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {

               
                Email = user.Email,
                City = user.City,
                LastName = user.LastName,
                Username = user.UserName,
                FirstName = user.FirstName,
                CellNumber = user.PhoneNumber,
                Relationship = user.Relationship,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            string uniqueFileName = UploadedFile(model);
            PopulateCityDropDownList();
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.City = model.City;
                user.LastName = model.LastName;
                user.ImagePath = uniqueFileName;
                user.FirstName = model.FirstName;
                user.AddressLine1 = model.AddressLine1;
                user.AddressLine2 = model.AddressLine2;
                user.Relationship = model.Relationship;

                PopulateCityDropDownList(model.City);

                await userManager.UpdateAsync(user);

                //await signInManager.RefreshSignInAsync(user);
                Notify("Your profile was updated successfully");


                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(EditCurrentUser));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

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
                LastName = user.LastName,
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                CellNumber = user.PhoneNumber,
                Relationship = user.Relationship,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                Province = user.Province,
                Country = user.Country,
                ZipCode = user.ZipCode,
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
            user.Relationship = model.Relationship;
            user.Province = model.Province;
            user.Country = model.Country;
            user.ZipCode = model.ZipCode;

            PopulateCityDropDownList(model.City);

            await userManager.UpdateAsync(user);

            await signInManager.RefreshSignInAsync(user);
            Notify("Your profile was updated successfully");
            return RedirectToAction(nameof(DetailUser));
        }
        [HttpGet]
        public async Task<IActionResult> DetailUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

                return View(user);
            
           
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
