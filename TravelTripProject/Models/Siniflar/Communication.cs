using System.ComponentModel.DataAnnotations;

namespace TravelTripProject.Models.Siniflar
{
    public class Communication
    {
        [Key]
        public int ID { get; set; }
        public string? NameSurname { get; set; }
        public string? Mail { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}