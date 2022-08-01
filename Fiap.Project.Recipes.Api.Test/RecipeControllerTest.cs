using Project.Recipes.Api.Controllers;
using Project.Recipes.Application.Interfaces;
using Project.Recipes.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Project.Recipes.Api.Test
{
    public class RecipeControllerTest
    {
        private readonly Mock<IRecipeAppService> _RecipeServiceMock;

        public RecipeControllerTest()
        {
            _RecipeServiceMock = new Mock<IRecipeAppService>();
        }

        [Fact]
        public async void Test_Get_Recipe_Por_Id()
        {
            //Arrange
            int RecipeId = 1;
            var Recipe = new Recipe() { Id = 1, Descricao = "Pudim", Titulo = "Sobremesas", Ingredientes = "Uma lata de leite conden...", Preparo = "Leve ao forno", CategoryId = 2 };
            _RecipeServiceMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(Recipe);
            //Act
            var RecipeController = new RecipesController(_RecipeServiceMock.Object);
            var actionResult = await RecipeController.Get(RecipeId);
            //Assert      
            Assert.Equal(actionResult.Value?.Id, RecipeId);

        }

        [Fact]
        public void Test_Insert_Recipe()
        {
            //Arrange
            int RecipeId = 1;
            var Recipe = new Recipe() { Id = 1, Descricao = "Pudim", Titulo = "Sobremesas", Ingredientes = "Uma lata de leite conden...", Preparo = "Leve ao forno", CategoryId = 2 };
            _RecipeServiceMock.Setup(x => x.Add(It.IsAny<Recipe>()));
            //Act
            var RecipeController = new RecipesController(_RecipeServiceMock.Object);
            var actionResult =  RecipeController.Insert(Recipe);

            //Assert          
            Assert.Equal(((ObjectResult)actionResult.Result).StatusCode, (int)System.Net.HttpStatusCode.Created);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as Recipe).Id, RecipeId);
        }

        [Fact]
        public async void Test_Delete_Recipe()
        {
            //Arrange
            int recipeId = 1;
            var recipe = new Recipe() { Id = 1, Descricao = "Pudim", Titulo = "Sobremesas", Ingredientes = "Uma lata de leite conden...", Preparo = "Leve ao forno", CategoryId = 2 };
            _RecipeServiceMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(recipe);
            //Act
            var RecipeController = new RecipesController(_RecipeServiceMock.Object);
            var actionResult = RecipeController.Get(recipeId);
            var actionResultDelete = await RecipeController.Delete(recipeId);
            //Assert          
            Assert.Equal(((NoContentResult)actionResultDelete).StatusCode, (int)System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public void Test_Update_Recipe()
        {
            //Arrange
            int recipeId = 1;
            var recipe = new Recipe() { Id = 1, Descricao = "Pudim", Titulo = "Sobremesas", Ingredientes = "Uma lata de leite conden...", Preparo = "Leve ao forno", CategoryId = 2 };
            _RecipeServiceMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(recipe);
            //Act
            var RecipeController = new RecipesController(_RecipeServiceMock.Object);
            var actionResult = RecipeController.Update(recipe);
            //Assert          
            Assert.Equal(((ObjectResult)actionResult.Result).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }
    }
}
