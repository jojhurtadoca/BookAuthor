using AutoMapper;
using BookAuthor.Models.Exceptions;
using Models.models;
using UserRoles.Data.IRepository;
using UserRoles.Dto;
using UserRoles.Exceptions;
using UserRoles.Models;
using UserRoles.Services.IService;

namespace UserRoles.Services
{
    public class UserService : IUserService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRoleRepository roleRepository, IUserRepository userRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public GetUserDTO mapperUser(User user)
        {
            return _mapper.Map<GetUserDTO>(user);
        }

        public async Task<GetUserDTO> Create(CreateUserDTO entity)
        {
            // We need to check if the username or email are avaiable
            var userFound = await _userRepository.GetByEmail(entity.Email);
            if (userFound != null)
            {
                throw new ConflictException("Email is not available");
            }

            var usernameFound = await _userRepository.GetByUsername(entity.Username);

            if (usernameFound != null)
            {
                throw new ConflictException("Username is not available");
            }

            // We need to get Roles
            var roles = new Role[entity.Roles.Length];

            foreach (var role in entity.Roles)
            {
                var r = await _roleRepository.GetByName(role);
                if (r != null)
                {
                    roles[roles.Length - 1] = r;
                }
            }

            var newUser = new User
            {
                Email = entity.Email,
                UserName = entity.Username,
                Password = entity.Password,
                Name = entity.Name,
                Roles = roles,
            };

            var userCreated = await _userRepository.Add(newUser);
            return mapperUser(userCreated);
        }

        public async Task<Boolean> Delete(Guid id)
        {
            var user = await _userRepository.Delete(id);

            return !!user;            
        }

        public async Task<IEnumerable<GetUserDTO>> GetAll()
        {
            var users = await _userRepository.GetAll();

            return users.ToList().ConvertAll(x => mapperUser(x));
        }

        public async Task<IEnumerable<GetUserDTO>> GetResultPaginated(int page, int limit)
        {
            var users = await _userRepository.GetUserWithRoles();

            if (users == null)
            {
                throw new NotFoundException("There are no books in DB");
            }

            var result = users.Skip((page - 1) * limit).Take(limit);

            return result.ToList().ConvertAll(x => mapperUser(x));
        }

        public async Task<GetUserDTO> GetById(Guid id)
        {
            return mapperUser(await _userRepository.GetById(id));
        }

        public async Task<GetUserDTO> Update(UpdateUserDTO entity)
        {
            var currentUser = await _userRepository.GetById(entity.Id);

            // We need to check if new email or new username are not in other accounts
            var allUsers = await _userRepository.GetAll();

            if (string.IsNullOrEmpty(entity.UserName))
            {
                var usernameNotAvaiable = allUsers.Where(user => user.UserName.Equals(entity.UserName) && user.Id != entity.Id).First();

                if (usernameNotAvaiable != null)
                {
                    throw new ConflictException("Username is not avaiable");
                }
            }

            if (string.IsNullOrEmpty(entity.Email)) 
            {
                var emailNotAvailable = allUsers.Where(user => user.Email.Equals(entity.Email) && user.Id != entity.Id).First();

                if (emailNotAvailable != null)
                {
                    throw new ConflictException("Email is not available");
                }
            }

            // We need to get Roles
            var roles = new Role[entity.Roles.Length];

            foreach (var role in entity.Roles)
            {
                var r = await _roleRepository.GetByName(role);
                if (r != null)
                {
                    roles[roles.Length - 1] = r;
                }
            }

            currentUser.UserName = string.IsNullOrEmpty(entity.UserName) ? entity.UserName : currentUser.UserName;
            currentUser.Email = string.IsNullOrEmpty(entity.Email) ? entity.Email : currentUser.Email;
            currentUser.Password = string.IsNullOrEmpty(entity.Password) ? entity.Password : currentUser.Password;
            currentUser.Name = string.IsNullOrEmpty(entity.Name) ? entity.Name : currentUser.Name;
            currentUser.Roles = roles.Length > 0 ? roles : currentUser.Roles;
            currentUser.UpdatedAt = DateTime.Now;

            var updatedUser = await _userRepository.Update(currentUser);

            return mapperUser(updatedUser);
        }
    }
}
