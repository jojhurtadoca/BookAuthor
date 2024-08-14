using BookAuthor.Data.Data.Repository.IRepository;
using BookAuthor.Models.Models;
using BookManagement.data.Data;
using BookManagement.data.Data.Repository;
using Microsoft.Extensions.Logging;

namespace BookAuthor.Data.Data.Repository
{
    public class GenderRepository: Repository<Gender>, IGenderRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly ILogger<GenderRepository> _logger;

        public GenderRepository(ApplicationDbContext dbContext, ILogger<GenderRepository> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}
