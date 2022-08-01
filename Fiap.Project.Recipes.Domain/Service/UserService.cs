using Project.Recipes.Domain.Interface.Repository;
using Project.Recipes.Domain.Interface.Services;
using Project.Recipes.Domain.Models;
using Project.Recipes.Domain.Service.Base;

namespace Project.Recipes.Domain.Service
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)   
        {
            _userRepository = userRepository;
        }

        public User Login(string login, string Password)
        {
            return _userRepository.Login(login, Password);
        }
    }
}
