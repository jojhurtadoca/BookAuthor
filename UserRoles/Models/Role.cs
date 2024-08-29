namespace UserRoles.Models
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Permission[] Permissions { get; set; }

    }
}
