using BookAuthor.Models.models;
using System.ComponentModel.DataAnnotations;

namespace BookAuthor.Models.Models
{
    public class RolePermission
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
