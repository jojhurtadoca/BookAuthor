using BookAuthor.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace BookAuthor.Models.models
{
    public class User: BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }

        public Guid RoleId { get; set; } // Foreign key property
        public Role Role { get; set; }   // Navigation property
    }
}
