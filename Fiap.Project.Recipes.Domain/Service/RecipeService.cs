using Project.Recipes.Domain.Interface.Repository;
using Project.Recipes.Domain.Interface.Services;
using Project.Recipes.Domain.Models;
using Project.Recipes.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Recipes.Domain.Service
{
    public class RecipeService : ServiceBase<Recipe>, IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository) : base(recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
    }
}
