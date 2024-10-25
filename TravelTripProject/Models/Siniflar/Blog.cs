using System.ComponentModel.DataAnnotations;

namespace TravelTripProject.Models.Siniflar
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? BlogImage { get; set; }
        public ICollection<Comments>? Comments { get; set; }

    }
}