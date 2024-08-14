using BookAuthor.Data.Data.Repository.IRepository;
using BookManagement.data.Data;
using BookManagement.data.Data.Repository;
using Microsoft.Extensions.Logging;
using Models.models;

namespace BookAuthor.Data.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public ApplicationDbContext _dbContext;
        private readonly ILogger<AuthorRepository> _logger;

        public AuthorRepository(ApplicationDbContext dbContext, ILogger<AuthorRepository> logger) : base(dbContext, logger)
        {

            _dbContext = dbContext;
            _logger = logger;
        }
    }
    
}
