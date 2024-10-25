using Microsoft.AspNetCore.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
	public class AboutController : Controller
	{
		TravelTripContext c = new TravelTripContext();
		public IActionResult Index()
		{
			var values = c.Abouts.ToList();
			return View(values);
		}
	}
}
