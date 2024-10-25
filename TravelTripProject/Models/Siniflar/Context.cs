using Microsoft.EntityFrameworkCore;


namespace TravelTripProject.Models.Siniflar
{
    public class TravelTripContext : DbContext
    {



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-Q1FO2EB\\SQLEXPRESS; initial catalog=TravelTripDb; integrated security=true;");
        }
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<Address>? Addresses { get; set; }
        public DbSet<About>? Abouts { get; set; }
        public DbSet<Comments>? Comments { get; set; }
        public DbSet<Communication>? Communications { get; set; }

    }

}