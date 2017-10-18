using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace W10_ASPNETCore_tute.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult RazorViewBagViewData()
        {
            var assignment1Mark = 20;
            var assignment2Mark = 15;
            var examMark = 55;
            var totalMark = assignment1Mark + assignment2Mark + examMark;
            ViewBag.MyTotalMark = totalMark;

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
