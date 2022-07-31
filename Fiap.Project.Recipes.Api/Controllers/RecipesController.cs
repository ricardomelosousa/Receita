using Fiap.Project.Recipes.Api.Helpers;
using Fiap.Project.Recipes.Application.Interfaces;
using Fiap.Project.Recipes.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {

        private readonly IRecipeService _RecipeService;

        public RecipesController(IRecipeService service)
        {
            _RecipeService = service;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Recipe> Get(int? id)
        {
            if (id == null)
                return NotFound();

            var Recipe = _RecipeService.Get(id.Value);

            if (Recipe == null)
                return NotFound();

            return Recipe;
        }

     
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetAll()
        {
            return Ok(_RecipeService.GetAll().ToList());
        }

        [HttpGet]
        [Route("PorCategory/{Category}")]
        public ActionResult<IEnumerable<Recipe>> GetAll(int Category)
        {
            var Recipes = _RecipeService.GetAll(Category).ToList();

            if (Recipes?.Count > 0)
                return Ok(Recipes);

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Category> Insert([FromBody] Recipe Recipe)
        {
            if (Recipe == null)
                return BadRequest();

            _RecipeService.Insert(Recipe);

            return Created($"/api/Recipe/{Recipe.Id}", Recipe);
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var Recipe = _RecipeService.Get(id);

            if (Recipe == null)
                return NotFound();

            _RecipeService.Delete(id);
            return NoContent();
        }

        [Authorize]
        [HttpPut]
        public ActionResult<Recipe> Update(Recipe Recipe)
        {
            if (ModelState.IsValid)
            {
                _RecipeService.Update(Recipe);
                return Ok(Recipe);
            }

            return BadRequest(ModelState);
        }

    }
}
