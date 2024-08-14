using BookAuthor.Data.Data.Repository.IRepository;

namespace BookAuthor.Data.Data.Repository.IUnitOfWork
{
    public interface IUnitOfWorkBook
    {
        IBookRepository Books { get; }

        Task CompleteAsync();
    }
}
