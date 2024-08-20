using BookAuthor.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Models.models
{
    public class Book: BaseEntity
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(2, ErrorMessage = "Title can not be less than two characters")]
        [MaxLength(150, ErrorMessage = "Title to long")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Genre ID can not be less than 1")]
        public Genre Genre { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Price can not be less than 1$")]
        public double Price { get; set; }

        [Required]
        public Author Author { get; set; }
    }
}
