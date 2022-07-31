using Fiap.Project.Recipes.Application.Interfaces;
using Fiap.Project.Recipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;

        public RecipeService(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public void Update(Recipe Recipe)
        {
            _repository.Update(Recipe);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Insert(Recipe Recipe)
        {
            _repository.Insert(Recipe);
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _repository.GetAll();
        }

        public Recipe Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Recipe> GetAll(int Category)
        {
            return _repository.GetAll(Category);
        }
    }
}
