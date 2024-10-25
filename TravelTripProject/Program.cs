using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TravelTripProject.Models.Siniflar;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
	options.LoginPath = "/Login/Login"; // Giri� sayfas� yolu
      options.LogoutPath = "/Account/Logout"; // ��k�� sayfas� yolu
        options.AccessDeniedPath = "/Account/AccessDenied"; // Eri�im reddedildi�i durumda y�nlendirme
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // �erez s�resi
});

builder.Services.AddAuthorization();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();



// DbContext'i hizmet olarak ekle
//builder.Services.AddDbContext<TravelTripContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
