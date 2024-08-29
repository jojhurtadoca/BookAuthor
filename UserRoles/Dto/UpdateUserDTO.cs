using System.ComponentModel.DataAnnotations;

namespace UserRoles.Dto
{
    public class UpdateUserDTO
    {
        [Required]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string[] Roles { get; set; }
    }
}
