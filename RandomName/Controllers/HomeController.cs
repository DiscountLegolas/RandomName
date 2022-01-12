using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomName.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RandomName.Controllers
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
            Names.TurkishName = null;
            Names.MaleName = null;
            Names.FemaleName = null;
            return View();
        }
        public IActionResult YeniİsimOluştur()
        {
            var vs = System.IO.File.ReadAllLines(@"C:\Users\prof1\source\repos\RandomName\RandomName\isimler.txt");
            Names.TurkishName = vs[new Random().Next(0, vs.Length - 1)];
            return View("~/Views/Home/Index.cshtml");
        }
        public IActionResult GenerateRandomEnglishMaleName()
        {
            var vs = System.IO.File.ReadAllLines(@"C:\Users\prof1\source\repos\RandomName\RandomName\Male.txt");
            Names.MaleName = vs[new Random().Next(0, vs.Length - 1)];
            return View("~/Views/Home/Index.cshtml");
        }
        public IActionResult GenerateRandomEnglishFemaleName()
        {
            var vs = System.IO.File.ReadAllLines(@"C:\Users\prof1\source\repos\RandomName\RandomName\Female.txt");
            Names.FemaleName = vs[new Random().Next(0, vs.Length - 1)];
            return View("~/Views/Home/Index.cshtml");
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
