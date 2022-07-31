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

    }
}
