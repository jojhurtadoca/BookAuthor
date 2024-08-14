using System.ComponentModel.DataAnnotations;

namespace BookAuthor.Models.Models
{
    public class Gender: BaseEntity
    {
        [Required(ErrorMessage = "Gender Name is required")]
        [MinLength(2, ErrorMessage = "Gender Name can not be less than two characters")]
        [MaxLength(150, ErrorMessage = "Gender Name to long")]
        public string Name { get; set; }
    }
}
