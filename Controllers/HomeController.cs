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
        // Define private fields for repository and context
        private IMummyRepository repo;
        private MummiesDbContext context;

        // Constructor that takes in the repository and context
        public HomeController(IMummyRepository temp, MummiesDbContext temp2)
        {
            repo = temp;
            context = temp2;
        }

        // Default action for home page
        public IActionResult Index()
        {
            return View();
        }

        // Action for burials page with optional filters and pagination
        public IActionResult Burials(string sex, string year, string depth, string age, string head, string hair, string face, string wrap, string area, int page = 1)
        {
            // Define number of items per page
            int pageSize = 40;

            // Query the database for filtered data based on the given filters
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

            // Count the total number of items and calculate the total number of pages based on the page size
            int totalItems = filteredData.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Join the filtered data with the textiles table and select the required fields
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

            // Sort the joined data by excavation year in descending order
            joinedData = joinedData.OrderByDescending(jd => !string.IsNullOrEmpty(jd.ExcavationYear) ? jd.ExcavationYear : "\uFFFF");

            // Skip the items based on the page number and take only the number of items specified by the page size
            joinedData = joinedData.Skip((page - 1) * pageSize).Take(pageSize);

            // Create a view model with the joined data, total number of pages, current page, and filters
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
                    //Bring in editable data
                    originalBurialmain.Fieldbookexcavationyear = editedBurialmain.Fieldbookexcavationyear;
                    originalBurialmain.Area = editedBurialmain.Area;
                    originalBurialmain.Sex = editedBurialmain.Sex;
                    originalBurialmain.Depth = editedBurialmain.Depth;
                    originalBurialmain.Ageatdeath = editedBurialmain.Ageatdeath;
                    originalBurialmain.Headdirection = editedBurialmain.Headdirection;
                    originalBurialmain.Haircolor = editedBurialmain.Haircolor;
                    originalBurialmain.Facebundles = editedBurialmain.Facebundles;
                    originalBurialmain.Wrapping = editedBurialmain.Wrapping;
                    originalBurialmain.Text = editedBurialmain.Text;
                    originalBurialmain.Samplescollected = editedBurialmain.Samplescollected;
                    originalBurialmain.Burialnumber = editedBurialmain.Burialnumber;
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