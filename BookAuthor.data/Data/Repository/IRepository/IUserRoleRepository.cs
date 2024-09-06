using BookAuthor.Models.Models;
using BookManagement.data.Data.Repository.IRepository;

namespace BookAuthor.Data.Data.Repository.IRepository
{
    public interface IUserRoleRepository: IRepository<UserRole>
    {
        Task<IEnumerable<UserRole>> GetUserRolesByUserId(Guid userId);
    }
}
