using UserRoles.Data.Repository.IRepository;
using UserRoles.Models;

namespace UserRoles.Data.IRepository
{
    public interface IRoleRepository: IRepository<Role>
    {
        Task<Role> GetByName(string name);
    }
}
