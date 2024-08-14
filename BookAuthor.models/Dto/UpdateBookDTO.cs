using Models.models;
using System.ComponentModel.DataAnnotations;

namespace BookAuthor.Models.Dto
{
    public class UpdateBookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Gender { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Author { get; set; }
    }
}
