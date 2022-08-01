

namespace Project.Recipes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryAppService _categoryService;

        public CategoriesController(ICategoryAppService service)
        {
            _categoryService = service;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Category>> Get(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _categoryService.GetById(id.Value);

            if (category == null)
                return NotFound();

            return category;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllAsync()
        {
            return Ok(await _categoryService.GetAll());
        }


        [Authorize]
        [HttpPost]
        public ActionResult<Category> Insert([FromBody] Category Category)
        {
            if (Category == null)
                return BadRequest();

            _categoryService.Add(Category);

            return Created($"/api/Category/{Category.Id}", Category);
        }


        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound();
            _categoryService.Remove(category);
            return NoContent();
        }


        [Authorize]
        [HttpPut]
        public ActionResult<Category> Update(Category Category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(Category);
                return Ok(Category);
            }

            return BadRequest(ModelState);
        }
    }
}
