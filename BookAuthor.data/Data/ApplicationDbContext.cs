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
        public DbSet<Gender> Gender { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Gabriel García Marquez" },
                new Author { Id = 2, Name = "Pablo Neruda" },
                new Author { Id = 3, Name = "Edgar Alan Poe" }
            );

            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = "Comedy" },
                new Gender { Id = 2, Name = "Sci fi" },
                new Gender { Id = 3, Name = "Medieval" }
            );
        }
    }
}
