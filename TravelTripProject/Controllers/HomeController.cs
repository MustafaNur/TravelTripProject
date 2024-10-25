using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelTripProject.Models;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        TravelTripContext c = new TravelTripContext();
        public IActionResult Index()
        {
           var values = c.Blogs.ToList();
            return View(values);
        }
        public IActionResult About()
        {
            return View();
        }
        public PartialViewResult PartialPromotion()
        {
            ;
            return PartialView();
        }
        public PartialViewResult PartialRhreeBlogs()
        {
            var Values = c.Blogs.OrderByDescending(x => x.ID).Take(1).ToList();
            return PartialView(Values);
        }
        public PartialViewResult PartialTopTenBlogs()
        {
            var value = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(value);
        }
        public PartialViewResult TopTenTitle()
        {
            return PartialView();
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
