using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WhosYourMummy.Models;
using WhosYourMummy.Models.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using WhosYourMummy.Data;

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
            var joinedData = from bm in repo.Burialmains
                             join bmt in repo.BurialmainTextiles on bm.Id equals bmt.MainBurialmainid into bmtGroup
                             from bmtLeft in bmtGroup.DefaultIfEmpty()
                             join t in repo.Textiles on (bmtLeft != null ? bmtLeft.MainTextileid : -1) equals t.Id into tGroup
                             from tLeft in tGroup.DefaultIfEmpty()
                             select new BurialTextileData
                             {
                                 BurialId = bm.Id,
                                 TextileBID = bmtLeft != null ? bmtLeft.MainBurialmainid : 0,
                                 TextileId = tLeft != null ? tLeft.Id : 0,
                                 TextileName = tLeft != null ? tLeft.Description : null,
                                 Area = bm.Area,
                                 Sex = bm.Sex
                             };

            var viewModel = new BurialTextileViewModel
            {
                JoinedData = joinedData.ToList()
            };

            return View(viewModel);
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