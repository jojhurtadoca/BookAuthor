namespace BookAuthor.Models.Dto
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public GenreDTO Genre { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public AuthorDTO Author { get; set; }
    }
}
