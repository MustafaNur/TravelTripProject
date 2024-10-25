using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        TravelTripContext c = new TravelTripContext();
        BlogComment bc = new BlogComment();
        public IActionResult Index()
        {
            //var BlogValues = c.Blogs.ToList();
            bc.Value1 = c.Blogs.ToList();
            bc.Value3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(bc);
        }

        public ActionResult BlogDetail(int id)
        {
            bc.Value1 = c.Blogs.Where(x => x.ID == id).ToList();
            bc.Value2 = c.Comments.Where(x => x.BlogsId == id).ToList();
            //var BlogFind = c.Blogs.Where(x=> x.ID == id).ToList();
            return View(bc);
        }
        [HttpGet]
        public PartialViewResult BlogComment(int id)
        {
            ViewBag.value = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult BlogComment(Comments comments)
        {
            
            
            c.Comments.Add(comments);
            c.SaveChanges();
            return PartialView();
        }
    }
}
