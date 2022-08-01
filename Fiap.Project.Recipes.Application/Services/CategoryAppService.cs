namespace Project.Recipes.Application.Services
{
    public class CategoryAppService : AppServiceBase<Category>, ICategoryAppService
    {
        private readonly ICategoryService _categoryService;

        public CategoryAppService(ICategoryService categoryService) : base(categoryService)
        {
            _categoryService = categoryService;
        }

       
    }
}
