using System.ComponentModel.DataAnnotations;

namespace BookAuthor.Models.Dto
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Roles are required")]
        public Guid[] Roles { get; set; }
    }
}
