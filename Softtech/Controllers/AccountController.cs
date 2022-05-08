using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Softtech.Data;
using Softtech.Models;
using Softtech.Services;
using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    
    public class AccountController : BaseController
    {
        private readonly ResManagementDBContext connContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly IEmailSender emailSender;

        public AccountController(ResManagementDBContext connContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger, IEmailSender emailSender)
        {
            this.connContext = connContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerView)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = registerView.FirstName,
                    LastName = registerView.LastName,
                    Email = registerView.EmailAddress,
                    UserName = registerView.FirstName
                };
                var result = await userManager.CreateAsync(user, registerView.Password);
                if (result.Succeeded)
                {
                    logger.LogInformation("User created a new account with password.");

                    var ctoken = userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                    var ctokenlink = Url.Action("ConfirmEmail", "Account", new
                    {
                        userId = user.Id,
                        token = ctoken
                    }, protocol: HttpContext.Request.Scheme);
                    await emailSender.SendEmailConfirmationAsync(user.Email, ctokenlink);

                    var isSave = await userManager.AddToRoleAsync(user, role: "Student");

                    await signInManager.SignInAsync(user, isPersistent: false);
                    logger.LogInformation("User created a new account with password.");

                    Notify("Hi " + user.UserName + " your account was created successfully! Please check your emails to confirm your account");

                    return RedirectToAction(nameof(AccountController.Login), "Account");
                }
                AddErrorsFromResult(result);
            }
            return View(registerView);
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginView, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = await userManager.FindByEmailAsync(loginView.EmailAddress);
                    if (user != null)
                    {
                        Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, loginView.Password, loginView.RememberMe, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            logger.LogInformation("User logged in.");
                            ////return RedirectToAction(nameof(AdminController.Index), "Admin");
                            return RedirectToLocal();
                        }
                    }
                }
                catch (Exception)
                {
                    Notify("You don't have access, please use you credetials to login", notificationType: NotificationType.warning);
                }
                ModelState.AddModelError("", "Invalid UserName or Password");
                Notify("Invalid credetials! Your email or password is incorrect", notificationType: NotificationType.error);
            }
            return View(loginView);
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await userManager.ConfirmEmailAsync(user, token);
            
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private IActionResult RedirectToLocal()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(AdminController.Index), "Admin");
            }
            else if (User.IsInRole("Student"))
            {
                return RedirectToAction(nameof(StudentsController.Index), "Students");
            }
            else if (User.IsInRole("Security") || User.IsInRole("Receptionist"))
            {
                return RedirectToAction(nameof(VisitorsController.Index), "Visitors");
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
