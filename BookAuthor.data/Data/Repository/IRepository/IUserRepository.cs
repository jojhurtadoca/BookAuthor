using BookAuthor.Models.models;
using BookManagement.data.Data.Repository.IRepository;

namespace BookAuthor.Data.Data.Repository.IRepository
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetByUsername(String username);

        Task<User> GetByEmail(String email);

        Task<User> GetByUsernameAndEmail(String username, String email);

        Task<List<User>> GetUserWithRoles();

    }
}
