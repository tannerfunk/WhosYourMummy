using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WhosYourMummy.Models;
using WhosYourMummy.Models.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using WhosYourMummy.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Microsoft.VisualBasic;

namespace WhosYourMummy.Controllers
{
    public class HomeController : Controller
    {

        private IMummyRepository repo;
        private MummiesDbContext context;

        public HomeController(IMummyRepository temp, MummiesDbContext temp2) {
            repo = temp;
            context = temp2;
        }

   

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Burials(string sex, string year, string depth, string age, string head, string hair, string face, string wrap, string area, int page = 1)
        {
            int pageSize = 40; // Number of items per page

            var filteredData = from bm in repo.Burialmains
                               where (bm.Sex == sex || sex == null)
                                     && (bm.Fieldbookexcavationyear == year || year == null)
                                     && (bm.Depth == depth || depth == null)
                                     && (bm.Ageatdeath == age || age == null)
                                     && (bm.Headdirection == head || head == null)
                                     && (bm.Haircolor == hair || hair == null)
                                     && (bm.Facebundles == face || face == null)
                                     && (bm.Wrapping == wrap || wrap == null)
                                     && (bm.Area == area || area == null)
                               select bm;

            int totalItems = filteredData.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var joinedData = from bm in filteredData
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
                                 Sex = bm.Sex,
                                 Depth = bm.Depth,
                                 AgeatDeath = bm.Ageatdeath,
                                 HeadDirection = bm.Headdirection,
                                 Haircolor = bm.Haircolor,
                                 FaceBundles = bm.Facebundles,
                                 Wrapping = bm.Wrapping
                             };

            joinedData = joinedData.OrderByDescending(jd => !string.IsNullOrEmpty(jd.ExcavationYear) ? jd.ExcavationYear : "\uFFFF");

            joinedData = joinedData.Skip((page - 1) * pageSize).Take(pageSize);


            var viewModel = new BurialTextileViewModel
            {
                JoinedData = joinedData.ToList(),
                TotalPages = totalPages,
                CurrentPage = page,
                Sex = sex,
                Year = year,
                Depth = depth,
                Age = age,
                Head = head,
                Hair = hair,
                Face = face,
                Wrap = wrap,
                Area = area
            };

            return View(viewModel);
        }


        //THIS BEGINS OUR CRUD STUFF

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Burialmain());
        }


        [HttpPost]
        public IActionResult Create(Burialmain newBurialmain, long currentID)
        {
            if (ModelState.IsValid)
            {
                context.Add(newBurialmain);
                context.SaveChanges();

                return RedirectToAction("Success");
            }

            return View(newBurialmain);
        }



        public IActionResult Edit(long id)
        {
            // Load the record with the specified id
            Burialmain burialMain = repo.Burialmains.FirstOrDefault(b => b.Id == id);

            if (burialMain == null)
            {
                return NotFound();
            }

            return View(burialMain);
        }

        [HttpPost]
        public IActionResult Edit(Burialmain editedBurialmain)
        {
            if (ModelState.IsValid)
            {
                Burialmain originalBurialmain = repo.Burialmains.FirstOrDefault(b => b.Id == editedBurialmain.Id);

                if (originalBurialmain != null)
                {
                    originalBurialmain.Fieldbookexcavationyear = editedBurialmain.Fieldbookexcavationyear;
                    originalBurialmain.Area = editedBurialmain.Area;
                    originalBurialmain.Sex = editedBurialmain.Sex;
                    // Update other fields as necessary

                    repo.SaveChanges();
                }

                return RedirectToAction("Burials");
            }

            return View(editedBurialmain);
        }

        public IActionResult Delete(long id)
        {
            var burial = repo.Burialmains.FirstOrDefault(b => b.Id == id);

            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var burial = repo.Burialmains.FirstOrDefault(b => b.Id == id);

            if (burial == null)
            {
                return NotFound();
            }

            repo.Remove(burial);
            repo.SaveChanges();

            return RedirectToAction("Burials");
        }

        //THIS ENDS OUR CRUD STUFF

        public IActionResult BurialDataDisplay(long id)
        {
            // Load the record with the specified id
            Burialmain burialMain = repo.Burialmains.FirstOrDefault(b => b.Id == id);

            if (burialMain == null)
            {
                return NotFound();
            }

            return View(burialMain);
        }

        public IActionResult Success()
        {
            return View();
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