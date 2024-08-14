using BookAuthor.Models.Dto;

namespace BookAuthor.Service.Service.IService
{
    public interface IBookService
    {
        Task<BookDTO> CreateBook(CreateBookDTO dto);

        Task<BookDTO> UpdateBook(UpdateBookDTO dto);

        Task<Boolean> DeleteBook(int id);

        Task<List<BookDTO>> FilterBooksByAuthor(int authorId, int pageNumber, int pageSize, Boolean orderByAsc);

        Task<List<BookDTO>> FilterBooksByGender(int genderId, int pageNumber, int pageSize, Boolean orderByAsc);

        Task<List<BookDTO>> FilterBooksByPriceRange(int startPrice, int endPrice, int pageNumber, int pageSize, Boolean orderByAsc);

        Task<List <BookDTO>> GetBooks(int pageNumber, int pageSize, Boolean orderByAsc);

        Task<BookDTO> GetBookById(int id);

        Task<BookDTO> GetTheMostExpensiveBook();

        Task<BookDTO> GetTheCheapestBook();

    }
}
