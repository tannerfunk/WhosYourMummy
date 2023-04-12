using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WhosYourMummy.Data;
using WhosYourMummy.Models;

namespace WhosYourMummy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MummyDbContext _db;

        public HomeController(ILogger<HomeController> logger, MummyDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Burials()
        {
            IQueryable<Burialmain> burialmain = _db.burialmain.AsQueryable();

            return View(burialmain);
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