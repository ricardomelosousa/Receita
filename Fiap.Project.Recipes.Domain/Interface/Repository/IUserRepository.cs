using Project.Recipes.Domain.Interface.Repository.Base;
using Project.Recipes.Domain.Models;

namespace Project.Recipes.Domain.Interface.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User Login(string login, string Password);
    }
}
