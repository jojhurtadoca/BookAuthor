using BookAuthor.Models.models;

namespace BookAuthor.Models.Models
{
    public class UserRole: BaseEntity
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
