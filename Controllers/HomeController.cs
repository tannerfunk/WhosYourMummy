using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WhosYourMummy.Models;
using WhosYourMummy.Models.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WhosYourMummy.Controllers
{
    public class HomeController : Controller
    {

        private IMummyRepository repo;

        public HomeController(IMummyRepository temp) => repo = temp;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Burials()
        {
            var x = new BurialmainsViewModel
            {
                Burialmains = repo.Burialmains
            };
            return View(x);
        }

        public IActionResult Supervised()
        {
            return View();
        }

        public IActionResult Unsupervised()
        {
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