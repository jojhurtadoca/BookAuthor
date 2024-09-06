using BookAuthor.Data.Data.Repository.IRepository;
using BookAuthor.Models.Models;
using BookManagement.data.Data;
using BookManagement.data.Data.Repository;
using Microsoft.Extensions.Logging;

namespace BookAuthor.Data.Data.Repository
{
    public class UserRoleRepository: Repository<UserRole>, IUserRoleRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly ILogger<UserRoleRepository> _logger;

        public UserRoleRepository(ApplicationDbContext dbContext, ILogger<UserRoleRepository> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<UserRole>> GetUserRolesByUserId(Guid userId)
        {
            return _dbContext.UserRoles.Where(x => x.UserId == userId);
        }
    }
}
