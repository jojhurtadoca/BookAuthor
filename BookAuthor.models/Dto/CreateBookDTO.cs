using System.ComponentModel.DataAnnotations;

namespace BookAuthor.Models.Dto
{
    public class CreateBookDTO
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(2, ErrorMessage = "Title can not be less than two characters")]
        [MaxLength(150, ErrorMessage = "Title to long")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Gender ID can not be less than 1")]
        public int Gender { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Gender can not be less than 1$")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Author ID can not be less than 1")]
        public int Author { get; set; }
    }
}
