using System.ComponentModel.DataAnnotations;

namespace TravelTripProject.Models.Siniflar
{
    public class About
    {
        [Key]
        public int ID { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}