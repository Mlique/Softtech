using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Softtech.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult help()
        {
            ViewData["Message"] = "Your help page.";

            return View();
        }

        public IActionResult AdminHelp()
        {
            ViewData["Message"] = "Admin Help";

            return View();
        }

        public IActionResult FAQ()
        {
            ViewData["Message"] = "FAQ page.";

            return View();
        }

        public IActionResult look()
        {
            ViewData["Message"] = "look page.";

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
