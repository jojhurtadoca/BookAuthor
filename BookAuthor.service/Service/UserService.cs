using AutoMapper;
using BookAuthor.Data.Data.Repository.IRepository;
using BookAuthor.Models.Dto;
using BookAuthor.Models.Exceptions;
using BookAuthor.Models.models;
using BookAuthor.Models.Models;
using BookAuthor.Service.Service.IService;

namespace BookAuthor.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;

        public UserService(IRoleRepository roleRepository, IUserRepository userRepository, IMapper mapper, IUserRoleRepository userRoleRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
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

            var roles = entity.Roles.ToHashSet();
            var rolesData = new HashSet<Role>();
            foreach (var role in roles) {
                var roleFound = await _roleRepository.GetById(role);

                if (roleFound == null)
                {
                    throw new NotFoundException("Role with ID " + role + " not found");
                }
                rolesData.Add(roleFound);
            }

            var newUser = new User
            {
                Email = entity.Email,
                UserName = entity.Username,
                Password = entity.Password,
                Name = entity.Name,
            };

            var userCreated = await _userRepository.Add(newUser);

            // We need to create the relationship between user and roles
            foreach (var role in rolesData)
            {

                var newUserRole = new UserRole
                {
                    UserId = newUser.Id,
                    User = newUser,
                    RoleId = role.Id,
                    Role = role,
                };
                await _userRoleRepository.Add(newUserRole);
            }
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

            var roles = entity.Roles.ToHashSet();
            var rolesData = new HashSet<Role>();
            foreach (var role in roles)
            {
                var roleFound = await _roleRepository.GetById(role);

                if (roleFound == null)
                {
                    throw new NotFoundException("Role with ID " + role + " not found");
                }
                rolesData.Add(roleFound);
            }

            currentUser.UserName = string.IsNullOrEmpty(entity.UserName) ? entity.UserName : currentUser.UserName;
            currentUser.Email = string.IsNullOrEmpty(entity.Email) ? entity.Email : currentUser.Email;
            currentUser.Password = string.IsNullOrEmpty(entity.Password) ? entity.Password : currentUser.Password;
            currentUser.Name = string.IsNullOrEmpty(entity.Name) ? entity.Name : currentUser.Name;
            currentUser.UpdatedAt = DateTime.Now;

            var updatedUser = await _userRepository.Update(currentUser);

            // We need to update the relationship between user and roles
            var userRoles = await _userRoleRepository.GetUserRolesByUserId(entity.Id);
            foreach (var role in rolesData)
            {
                // We need to find if the role has been added before
                var userRoleAdded = userRoles.Where(x => x.RoleId == role.Id).First();
                if (userRoleAdded == null)
                {
                    // This means, this role has not been added before, so we can create the entity, if 
                    // the role has been added, we don't have to do nothing
                    var newUserRole = new UserRole
                    {
                        UserId = updatedUser.Id,
                        User = updatedUser,
                        RoleId = role.Id,
                        Role = role,
                    };

                    await _userRoleRepository.Add(newUserRole);
                }
            }

            return mapperUser(updatedUser);
        }
    }
}
