namespace Project.Recipes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {

        private readonly IRecipeAppService _recipeAppService;

        public RecipesController(IRecipeAppService recipeAppService)
        {
            _recipeAppService = recipeAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Recipe>> Get(int? id)
        {
            if (id == null)
                return NotFound();

            var recipe = await _recipeAppService.GetById(id.Value);

            if (recipe == null)
                return NotFound();
            return recipe;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAll()
        {
            return Ok(await _recipeAppService.GetAll());
        }

        [HttpGet]
        [Route("PorCategory/{Category}")]
        public async Task<ActionResult<Recipe>> GetAll(int categoriaId)
        {
            var recipe = await _recipeAppService.FindBy(a => a.CategoryId == categoriaId, true);

            if (recipe != null)
                return Ok(recipe);

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Category> Insert([FromBody] Recipe recipe)
        {
            if (recipe == null)
                return BadRequest();

            _recipeAppService.Add(recipe);

            return Created($"/api/Recipe/{recipe.Id}", recipe);
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var recipe = await _recipeAppService.GetById(id);

            if (recipe == null)
                return NotFound();

            _recipeAppService.Remove(recipe);
            return NoContent();
        }

        [Authorize]
        [HttpPut]
        public ActionResult<Recipe> Update(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _recipeAppService.Update(recipe);
                return Ok(recipe);
            }
            return BadRequest(ModelState);
        }

    }
}
