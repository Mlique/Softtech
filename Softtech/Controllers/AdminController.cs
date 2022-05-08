using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Softtech.Data;
using Softtech.Models;
using Softtech.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    [Authorize(Roles = "Receptionist, Admin")]
    public class AdminController : Controller
    {
        private readonly ResManagementDBContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IInspectionRepository repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(ResManagementDBContext context, UserManager<ApplicationUser> userManager, IInspectionRepository repository, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.userManager = userManager;
            this.repository = repository;
            _webHostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var bookings =  context.TblBookings.ToList().Count();
            ViewBag.BookingList = bookings;

            var stud = await userManager.GetUsersInRoleAsync("Student");
            var studListItems = stud.Select(nrs => new SelectListItem
            {
                Value = nrs.Id
            })
            .ToList().Count();

            ViewBag.StudCounter = studListItems;

            var rooms = context.TblRooms.ToList().Count();
            ViewBag.RoomList = rooms;

            var avrRooms = context.TblRooms.ToList().Count();
            ViewBag.AvaRoomList = avrRooms;

            return View(new Helper());
        }
        public IActionResult ManageUser()
        {
            return View();
        }
    }
}
