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
        }
    }
}
