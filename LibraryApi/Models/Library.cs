using System.ComponentModel.DataAnnotations;

namespace trackingapi.Models
{
    public class Library
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        public int NumberOfPages { get; set; }
    }
}
