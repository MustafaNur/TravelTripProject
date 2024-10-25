using System.ComponentModel.DataAnnotations;

namespace TravelTripProject.Models.Siniflar
{
    public class Comments
    {
        [Key]
        public int CommentsID { get; set; }
        public string? UserName { get; set; }
        public string? UserMail { get; set; }
        public string? UserComment { get; set; }
        public int BlogsId { get; set; }
        public virtual Blog? Blog {get; set;}
    }
}