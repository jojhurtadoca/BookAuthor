using Microsoft.EntityFrameworkCore;
using UserRoles.Data.IRepository;
using UserRoles.Models;

namespace UserRoles.Data
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public readonly AppDbContext _dbContext;
        private readonly ILogger<RoleRepository> _logger;

        public RoleRepository(AppDbContext dbContext, ILogger<RoleRepository> logger) : base(dbContext, logger)
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
