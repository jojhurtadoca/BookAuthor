using BookAuthor.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace BookAuthor.Models.models
{
    public class Permission
    {
        [Key]
        public Guid Id { get; set; }
        public string PermissionType { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    }
}
