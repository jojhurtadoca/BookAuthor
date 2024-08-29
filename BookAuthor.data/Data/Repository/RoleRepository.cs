using BookAuthor.Data.Data.Repository.IRepository;
using BookAuthor.Models.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookManagement.data.Data.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly ILogger<RoleRepository> _logger;

        public RoleRepository(ApplicationDbContext dbContext, ILogger<RoleRepository> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<Role> GetByName(string name)
        {
            return _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
