using BookAuthor.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Models.models
{
    public class Author : BaseEntity
    {

        [Required(ErrorMessage = "Author Name is required")]
        [MinLength(2, ErrorMessage = "Author Name can not be less than two characters")]
        [MaxLength(150, ErrorMessage = "Author Name to long")]
        public string Name { get; set; }
    }
}
