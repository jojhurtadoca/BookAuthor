
using BookAuthor.Models.Dto;

namespace BookAuthor.Service.Service.IService
{
    public interface IUserService: IService<GetUserDTO, CreateUserDTO, UpdateUserDTO>
    {}
}
