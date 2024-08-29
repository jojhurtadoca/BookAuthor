using BookAuthor.Models.models;
using BookManagement.data.Data.Repository.IRepository;

namespace BookAuthor.Data.Data.Repository.IRepository
{
    public interface IRoleRepository: IRepository<Role>
    {
        Task<Role> GetByName(string name);
    }
}
