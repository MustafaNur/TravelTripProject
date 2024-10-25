using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TravelTripProject.Models.Siniflar;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace TravelTripProject.Controllers
{
    public class LoginController : Controller
    {
        TravelTripContext c = new TravelTripContext();
        public IActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public IActionResult Login()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Login(string username, string password)
		{
			// Kullanıcıyı doğrulamak için veritabanını sorguluyoruz
			var user = c.Admins.SingleOrDefault(u => u.AdminNick == username && u.AdminPass == password);

			if (user != null)
			{
				// Kullanıcı geçerli, kimlik doğrulama için claim'leri oluşturuyoruz
				var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.AdminNick),
				new Claim(ClaimTypes.NameIdentifier, user.AdminID.ToString())
			};

				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var authProperties = new AuthenticationProperties
				{
					IsPersistent = true // Kalıcı oturum açmak için
				};

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

				return RedirectToAction("Index", "Admin");
			}

			ModelState.AddModelError("", "Geçersiz kullanıcı adı veya parola");
			return View();
		}
	}
}
