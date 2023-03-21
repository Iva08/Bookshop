using System.ComponentModel.DataAnnotations;

namespace BookshopApplication.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,1000)]
        public double Price { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
