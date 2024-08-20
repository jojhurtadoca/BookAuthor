namespace BookAuthor.Models.Dto
{
    public class UpdateBookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public Guid Genre { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public Guid Author { get; set; }
    }
}
