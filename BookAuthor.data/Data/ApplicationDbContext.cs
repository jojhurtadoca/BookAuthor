using BookAuthor.Models.models;
using BookAuthor.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.models;

namespace BookManagement.data.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Author {  get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Genre> Genre { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = Guid.NewGuid(), Name = "Gabriel García Marquez" },
                new Author { Id = Guid.NewGuid(), Name = "Pablo Neruda" },
                new Author { Id = Guid.NewGuid(), Name = "Edgar Alan Poe" }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = Guid.NewGuid(), Name = "Comedy" },
                new Genre { Id = Guid.NewGuid(), Name = "Sci fi" },
                new Genre { Id = Guid.NewGuid(), Name = "Medieval" }
            );

            modelBuilder.Entity<UserRole>()
                .HasKey(rp => new { rp.RoleId, rp.UserId });

            modelBuilder.Entity<UserRole>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(rp => rp.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(rp => rp.UserId);

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);

            var roleSuperAdminId = Guid.NewGuid();
            var roleAdminId = Guid.NewGuid();
            var roleUserId = Guid.NewGuid();

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = roleSuperAdminId, Name = "ROLE_SUPER_ADMIN" },
                new Role { Id = roleAdminId, Name = "ROLE_ADMIN" },
                new Role { Id = roleUserId, Name = "ROLE_USER" }
            );

            var user1Id = Guid.NewGuid();
            var user2Id = Guid.NewGuid();
            var user3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User { Id = user1Id, Name = "User1", Email = "email@email.com", Password = "Password", UserName = "username1" },
                new User { Id = user2Id, Name = "User2", Email = "email2@email.com", Password = "Password2", UserName = "username2" },
                new User { Id = user3Id, Name = "User3", Email = "email3@email.com", Password = "Password3", UserName = "username3" }
            );

            var permissionCreateId = Guid.NewGuid();
            var permissionUpdateId = Guid.NewGuid();
            var permissionDeleteId = Guid.NewGuid();
            var permissionViewId = Guid.NewGuid();

            modelBuilder.Entity<Permission>().HasData(new Permission { Id = permissionCreateId, PermissionType = "CREATE" },
                new Permission { Id = permissionUpdateId, PermissionType = "UPDATE" },
                new Permission { Id = permissionDeleteId, PermissionType = "VIEW" },
                new Permission { Id = permissionViewId, PermissionType = "DELETE" }
            );

            // Seed RolePermissions (linking table) - Assign same permission to multiple roles
            modelBuilder.Entity<RolePermission>().HasData(
                new RolePermission { Id = Guid.NewGuid(), RoleId = roleSuperAdminId, PermissionId = permissionCreateId },
                new RolePermission { Id = Guid.NewGuid(), RoleId = roleSuperAdminId, PermissionId = permissionUpdateId },
                new RolePermission { Id = Guid.NewGuid(), RoleId = roleSuperAdminId, PermissionId = permissionDeleteId },
                new RolePermission { Id = Guid.NewGuid(), RoleId = roleSuperAdminId, PermissionId = permissionViewId },
                new RolePermission { Id = Guid.NewGuid(), RoleId = roleAdminId, PermissionId = permissionCreateId },
                new RolePermission { Id = Guid.NewGuid(), RoleId = roleAdminId, PermissionId = permissionUpdateId },
                new RolePermission { Id = Guid.NewGuid(), RoleId = roleAdminId, PermissionId = permissionViewId },
                new RolePermission { Id = Guid.NewGuid(), RoleId = roleUserId, PermissionId = permissionViewId }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = Guid.NewGuid(), RoleId = roleSuperAdminId, UserId = permissionCreateId },
                new UserRole { Id = Guid.NewGuid(), RoleId = roleAdminId, UserId = permissionUpdateId },
                new UserRole { Id = Guid.NewGuid(), RoleId = roleUserId, UserId = permissionDeleteId },
                new UserRole { Id = Guid.NewGuid(), RoleId = roleAdminId, UserId = permissionViewId },
                new UserRole { Id = Guid.NewGuid(), RoleId = roleUserId, UserId = permissionCreateId },
                new UserRole { Id = Guid.NewGuid(), RoleId = roleUserId, UserId = permissionUpdateId }
            );
        }
    }
}
