using Microsoft.AspNetCore.Mvc;
using Softtech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    public class ChartsController : Controller
    {
        public IActionResult Index()
        {
            return View(new Helper());
        }
    }
}
