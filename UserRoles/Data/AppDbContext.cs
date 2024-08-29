using BookAuthor.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.models;
using UserRoles.Models;

namespace UserRoles.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Permission[] arrayPermisions =
            {
                new Permission { Id = Guid.NewGuid(), PermissionType = "CREATE" },
                new Permission { Id = Guid.NewGuid(), PermissionType = "UPDATE" },
                new Permission { Id = Guid.NewGuid(), PermissionType = "VIEW" },
                new Permission { Id = Guid.NewGuid(), PermissionType = "DELETE" },
            };

            // Seed data
            modelBuilder.Entity<Permission>().HasData(arrayPermisions);

            Role[] roles =
            {
                new Role { Id = Guid.NewGuid(), Name = "ROLE_SUPER_ADMIN", Permissions = arrayPermisions },
                new Role { Id = Guid.NewGuid(), Name = "ROLE_ADMIN", Permissions = arrayPermisions.Where(s => !s.PermissionType.Equals("DELETE")).ToArray() },
                new Role { Id = Guid.NewGuid(), Name = "ROLE_USER", Permissions = arrayPermisions.Where(s => s.PermissionType.Equals("VIEW")).ToArray() }
            };

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<User>()
                .HasIndex(e => e.UserName)
                .IsUnique()
                .IsClustered();

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Email)
                .IsUnique()
                .IsClustered();

            modelBuilder.Entity<User>().HasData(
                   new User { Id = Guid.NewGuid(), Name = "User1", Email= "email@email.com", Password="Password", UserName="username1", Roles= roles.Where(r => r.Name.Equals("ROLE_USER")).ToArray()},
                   new User { Id = Guid.NewGuid(), Name = "User2", Email = "email2@email.com", Password = "Password2", UserName = "username2", Roles = roles.Where(r => r.Name.Equals("ROLE_ADMIN")).ToArray() },
                   new User { Id = Guid.NewGuid(), Name = "User2", Email = "email2@email.com", Password = "Password2", UserName = "username2", Roles = roles.Where(r => r.Name.Equals("ROLE_SUPER_ADMIN")).ToArray() }
            );
        }
    }
}
