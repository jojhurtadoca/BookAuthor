using BookAuthor.Models.Models;
using Models.models;
using System.Reflection;

namespace BookAuthor.Models.Dto
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public GenderDTO Gender { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public AuthorDTO Author { get; set; }
    }
}
