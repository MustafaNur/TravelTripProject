using System.ComponentModel.DataAnnotations;

namespace TravelTripProject.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string? AdminNick { get; set; }
        public string? AdminPass { get; set; }
    }
}