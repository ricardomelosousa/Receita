using Fiap.Project.Recipes.Application.Interfaces;
using Fiap.Project.Recipes.Domain.Models;
using Fiap.Project.Recipes.Persistence.Contexts;
using System;
using System.Linq;

namespace Fiap.Project.Recipes.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlDataContext _dataContext;

        public UserRepository(SqlDataContext context)
        {
            _dataContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public User Login(string login, string senha)
        {
            return _dataContext.Users.FirstOrDefault(s => s.Login == login && s.Senha == senha);
        }

        public User Get(int UserId)
        {
            return _dataContext.Users.Find(UserId);

        }

        public int SalvarUser(User User)
        {
            _dataContext.Users.Add(User);
            _dataContext.SaveChanges();
            return User.Id;
        }
    }
}
