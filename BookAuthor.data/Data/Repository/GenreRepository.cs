using BookAuthor.Data.Data.Repository.IRepository;
using BookAuthor.Models.Models;
using BookManagement.data.Data;
using BookManagement.data.Data.Repository;
using Microsoft.Extensions.Logging;

namespace BookAuthor.Data.Data.Repository
{
    public class GenreRepository: Repository<Genre>, IGenreRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly ILogger<GenreRepository> _logger;

        public GenreRepository(ApplicationDbContext dbContext, ILogger<GenreRepository> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}
