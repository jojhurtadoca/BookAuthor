using BookAuthor.Data.Data.Repository.IRepository;
using BookManagement.data.Data;
using BookManagement.data.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.models;

namespace BookAuthor.Data.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(ApplicationDbContext dbContext, ILogger<BookRepository> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<Book>> GetBooksWithDetails()
        {
            return _dbContext.Set<Book>()
                .Include(g => g.Genre)
                .Include(g => g.Author)
                .ToList();
        }
    }
}
