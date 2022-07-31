using Fiap.Project.Recipes.Application.Interfaces;
using Fiap.Project.Recipes.Domain.Models;
using Fiap.Project.Recipes.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Persistence.Repositories
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
    }
}
