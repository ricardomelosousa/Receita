using Fiap.Project.Recipes.Api.Helpers;
using Fiap.Project.Recipes.Application.Interfaces;
using Fiap.Project.Recipes.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;

        public CategoriesController(ICategoryService service)
        {
            _CategoryService = service;
        }


      
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Category> Get(int? id)
        {
            if (id == null)
                return NotFound();

            var Category = _CategoryService.Get(id.Value);

            if (Category == null)
                return NotFound();

            return Category;
        }


      
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            return Ok(_CategoryService.GetAll().ToList());
        }


        [Authorize]
        [HttpPost]
        public ActionResult<Category> Insert([FromBody]Category Category)
        {
            if (Category == null)
                return BadRequest();

            _CategoryService.Insert(Category);

            return Created($"/api/Category/{Category.Id}", Category);
        }


        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var catagoria = _CategoryService.Get(id);

            if (catagoria == null)
                return NotFound();
            
            _CategoryService.Delete(id);
            return NoContent();
        }


        [Authorize]
        [HttpPut]
        public ActionResult<Category> Update(Category Category)
        {
            if (ModelState.IsValid)
            {
                _CategoryService.Update(Category);
                return Ok(Category);
            }

            return BadRequest(ModelState);
        }
    }
}
