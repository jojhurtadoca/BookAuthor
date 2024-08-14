using BookAuthor.Data.Data.Repository.IRepository;
using BookAuthor.Data.Data.Repository.IUnitOfWork;
using BookManagement.data.Data;
using Microsoft.Extensions.Logging;

namespace BookAuthor.Data.Data.Repository
{
    public class UnitOfWorkBook: IUnitOfWorkBook, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BookRepository> _logger;

        public IBookRepository Books { get; private set; }

        public UnitOfWorkBook(
            ApplicationDbContext context, ILogger<BookRepository> logger
            )
        {
            _context = context;
            _logger = logger;

            Books = new BookRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
