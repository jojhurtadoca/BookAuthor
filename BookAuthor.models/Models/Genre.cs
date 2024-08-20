using System.ComponentModel.DataAnnotations;

namespace BookAuthor.Models.Models
{
    public class Genre: BaseEntity
    {
        [Required(ErrorMessage = "Genre Name is required")]
        [MinLength(2, ErrorMessage = "Genre Name can not be less than two characters")]
        [MaxLength(150, ErrorMessage = "Genre Name to long")]
        public string Name { get; set; }
    }
}
