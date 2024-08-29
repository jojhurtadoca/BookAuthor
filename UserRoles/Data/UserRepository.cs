using Microsoft.EntityFrameworkCore;
using Models.models;
using UserRoles.Data.IRepository;
using UserRoles.Models;

namespace UserRoles.Data
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public readonly AppDbContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext dbContext, ILogger<UserRepository> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<User>> GetUserWithRoles()
        {
            return _dbContext.Set<User>()
                .Include(d => d.Roles)
                .ToList();
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.UserName.Equals(username));
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task<User> GetByUsernameAndEmail(string username, string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(email) || user.UserName.Equals(username));
        }
    }
}
