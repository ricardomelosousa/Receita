using Project.Recipes.Domain.Interface.Repository;
using Project.Recipes.Domain.Models;
using Project.Recipes.Persistence.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Recipes.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlDataContext _dataContext;

        public UserRepository(SqlDataContext context)
        {
            _dataContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public User Login(string login, string Password)
        {
            return _dataContext.Users.FirstOrDefault(s => s.Login == login && s.Password == Password);
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

        public Task<int> Add(User obj)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindBy(Func<User, bool> predicate, bool @readonly)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(User obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(User id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<User>> GetAllByParamenter(Func<User, bool> predicate, bool @readonly)
        {
            throw new NotImplementedException();
        }
    }
}
