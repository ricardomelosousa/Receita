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
    public class RecipeRepository : IRecipeRepository
    {
        private readonly SqlDataContext _dataContext;

        public RecipeRepository(SqlDataContext context)
        {
            _dataContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Update(Recipe Recipe)
        {
            _dataContext.Entry(Recipe).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var Recipe = _dataContext.Categorys.Find(id);

            if (Recipe != null)
            {
                _dataContext.Categorys.Remove(Recipe);
                _dataContext.SaveChanges();
            }
        }

        public void Insert(Recipe Recipe)
        {
            _dataContext.Recipes.Add(Recipe);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _dataContext.Recipes.ToList();
        }

        public Recipe Get(int id)
        {
            var Recipe = _dataContext.Recipes.FirstOrDefault(m => m.Id == id);
            _dataContext.Entry(Recipe).Reference(r => r.CategoryRecipe).Load();
            return Recipe;
        }

        public IEnumerable<Recipe> GetAll(int Category)
        {
            return _dataContext.Recipes
                .Where(Recipe => Recipe.CategoryId == Category)
                .ToList();
        }

        public Task<int> Add(Recipe obj)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> FindBy(Func<Recipe, bool> predicate, bool @readonly)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<Recipe>> IRepositoryBase<Recipe>.GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Recipe id)
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

        public Task<IQueryable<Recipe>> GetAllByParamenter(Func<Recipe, bool> predicate, bool @readonly)
        {
            throw new NotImplementedException();
        }
    }
}
