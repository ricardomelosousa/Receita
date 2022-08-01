using Project.Recipes.Domain.Interface.Repository;
using Project.Recipes.Domain.Interface.Repository.Base;
using Project.Recipes.Domain.Models;
using Project.Recipes.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Recipes.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlDataContext _dataContext;

        public CategoryRepository(SqlDataContext context)
        {
            _dataContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Update(Category Category)
        {
            _dataContext.Entry(Category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var Category = _dataContext.Categorys.Find(id);

            if (Category != null)
            {
                _dataContext.Categorys.Remove(Category);
                _dataContext.SaveChanges();
            }
        }

        public void Insert(Category Category)
        {
            _dataContext.Categorys.Add(Category);
            _dataContext.SaveChanges();
        }

        public Category Get(int id)
        {
            return _dataContext.Categorys.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _dataContext.Categorys.ToList();
        }

        public Task<int> Add(Category obj)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> FindBy(Func<Category, bool> predicate, bool @readonly)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<Category>> IRepositoryBase<Category>.GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Category id)
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

        public Task<IQueryable<Category>> GetAllByParamenter(Func<Category, bool> predicate, bool @readonly)
        {
            throw new NotImplementedException();
        }
    }
}
