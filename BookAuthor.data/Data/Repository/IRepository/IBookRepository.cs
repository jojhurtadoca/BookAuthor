using BookManagement.data.Data.Repository.IRepository;
using Models.models;

namespace BookAuthor.Data.Data.Repository.IRepository
{
    public interface IBookRepository: IRepository<Book>
    {
        public Task<List<Book>> GetBooksWithDetails();
    }
}
