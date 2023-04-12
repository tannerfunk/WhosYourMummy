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

        public IActionResult Burials(int page = 1)
        {
            int pageSize = 40; // Number of items per page
            int totalItems = repo.Burialmains.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var joinedData = from bm in repo.Burialmains
                             join bmt in repo.BurialmainTextiles on bm.Id equals bmt.MainBurialmainid into bmtGroup
                             from bmtLeft in bmtGroup.DefaultIfEmpty()
                             join t in repo.Textiles on (bmtLeft != null ? bmtLeft.MainTextileid : -1) equals t.Id into tGroup
                             from tLeft in tGroup.DefaultIfEmpty()
                             select new BurialTextileData
                             {
                                 BurialId = bm.Id,
                                 ExcavationYear = bm.Fieldbookexcavationyear,
                                 TextileId = tLeft != null ? tLeft.Id : 0,
                                 TextileName = tLeft != null ? tLeft.Description : null,
                                 Area = bm.Area,
                                 Sex = bm.Sex
                             };

            joinedData = joinedData.OrderByDescending(jd => !string.IsNullOrEmpty(jd.ExcavationYear) ? jd.ExcavationYear : "\uFFFF");


            joinedData = joinedData.Skip((page - 1) * pageSize).Take(pageSize);

            var viewModel = new BurialTextileViewModel
            {
                JoinedData = joinedData.ToList(),
                TotalPages = totalPages,
                CurrentPage = page
            };

            return View(viewModel);
        }

        //THIS BEGINS OUR CRUD STUFF

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BurialTextileData model)
        {
            if (ModelState.IsValid)
            {
                // Save the new record to the database
                //repo.Add(model);
                //repo.SaveChanges();
            }
            return RedirectToAction("Burials");
        }

        public IActionResult Edit(long id)
        {
            // Load the record with the specified id
            return View(/* record */);
        }

        [HttpPost]
        public IActionResult Edit(BurialTextileData model)
        {
            if (ModelState.IsValid)
            {
                // Update the record in the database
            }
            return RedirectToAction("Burials");
        }

        public IActionResult Delete(long id)
        {
            // Delete the record with the specified id
            return RedirectToAction("Burials");
        }

        //THIS ENDS OUR CRUD STUFF



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