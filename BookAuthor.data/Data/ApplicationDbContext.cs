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
                new Author { Id = 1, Name = "Gabriel García Marquez" },
                new Author { Id = 2, Name = "Pablo Neruda" },
                new Author { Id = 3, Name = "Edgar Alan Poe" }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Comedy" },
                new Genre { Id = 2, Name = "Sci fi" },
                new Genre { Id = 3, Name = "Medieval" }
            );
        }
    }
}
