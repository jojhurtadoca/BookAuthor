namespace BookAuthor.Models.Dto
{
    public class UpdateBookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Genre { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Author { get; set; }
    }
}
