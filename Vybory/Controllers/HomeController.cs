using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vybory.Models;

namespace Vybory.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("View1");
        }

        public IActionResult Index2()
        {
            return View("View2");
        }

        public IActionResult InstructionFoVote()
        {
            return View("InstructionFoVote");
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

      
    }
}
