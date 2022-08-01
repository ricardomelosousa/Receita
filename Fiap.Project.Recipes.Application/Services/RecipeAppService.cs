namespace Project.Recipes.Application.Services
{
    public class RecipeAppService : AppServiceBase<Recipe>, IRecipeAppService
    {
        private readonly IRecipeService _recipeService;

        public RecipeAppService(IRecipeService recipeService) : base(recipeService)
        {
            _recipeService = recipeService;
        }

      
    }
}
