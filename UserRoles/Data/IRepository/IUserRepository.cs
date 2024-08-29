using UserRoles.Data.Repository.IRepository;
using UserRoles.Models;

namespace UserRoles.Data.IRepository
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetByUsername(String username);

        Task<User> GetByEmail(String email);

        Task<User> GetByUsernameAndEmail(String username, String email);

        Task<List<User>> GetUserWithRoles();

    }
}
