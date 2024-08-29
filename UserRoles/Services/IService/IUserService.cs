using UserRoles.Dto;

namespace UserRoles.Services.IService
{
    public interface IUserService: IService<GetUserDTO, CreateUserDTO, UpdateUserDTO>
    {}
}
