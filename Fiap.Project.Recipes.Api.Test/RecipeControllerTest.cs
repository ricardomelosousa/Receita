using Fiap.Project.Recipes.Api.Controllers;
using Fiap.Project.Recipes.Application.Interfaces;
using Fiap.Project.Recipes.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Fiap.Project.Recipes.Api.Test
{
    public class RecipeControllerTest
    {
        private readonly Mock<IRecipeService> _RecipeServiceMock;

        public RecipeControllerTest()
        {
            _RecipeServiceMock = new Mock<IRecipeService>();
        }

        [Fact]
        public void Test_Get_Recipe_Por_Id()
        {
            //Arrange
            int RecipeId = 1;
            var Recipe = new Recipe() { Id = 1, Descricao = "Pudim", Titulo = "Sobremesas", Ingredientes = "Uma lata de leite conden...", Preparo = "Leve ao forno", CategoryId = 2 };
            _RecipeServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Recipe);
            //Act
            var RecipeController = new RecipesController(_RecipeServiceMock.Object);
            var actionResult = RecipeController.Get(RecipeId);
            //Assert      
            Assert.Equal(actionResult.Value.Id, RecipeId);

        }

        [Fact]
        public void Test_Insert_Recipe()
        {
            //Arrange
            int RecipeId = 1;
            var Recipe = new Recipe() { Id = 1, Descricao = "Pudim", Titulo = "Sobremesas", Ingredientes = "Uma lata de leite conden...", Preparo = "Leve ao forno", CategoryId = 2 };
            _RecipeServiceMock.Setup(x => x.Insert(It.IsAny<Recipe>()));
            //Act
            var RecipeController = new RecipesController(_RecipeServiceMock.Object);
            var actionResult = RecipeController.Insert(Recipe);

            //Assert          
            Assert.Equal(((ObjectResult)actionResult.Result).StatusCode, (int)System.Net.HttpStatusCode.Created);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as Recipe).Id, RecipeId);
        }

        [Fact]
        public void Test_Delete_Recipe()
        {
            //Arrange
            int RecipeId = 1;
            var Recipe = new Recipe() { Id = 1, Descricao = "Pudim", Titulo = "Sobremesas", Ingredientes = "Uma lata de leite conden...", Preparo = "Leve ao forno", CategoryId = 2 };
            _RecipeServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Recipe);
            //Act
            var RecipeController = new RecipesController(_RecipeServiceMock.Object);
            var actionResult = RecipeController.Get(RecipeId);
            var actionResultDelete = RecipeController.Delete(RecipeId);
            //Assert          
            Assert.Equal(((NoContentResult)actionResultDelete).StatusCode, (int)System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public void Test_Update_Recipe()
        {
            //Arrange
            int RecipeId = 1;
            var Recipe = new Recipe() { Id = 1, Descricao = "Pudim", Titulo = "Sobremesas", Ingredientes = "Uma lata de leite conden...", Preparo = "Leve ao forno", CategoryId = 2 };
            _RecipeServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Recipe);
            //Act
            var RecipeController = new RecipesController(_RecipeServiceMock.Object);
            var actionResult = RecipeController.Update(Recipe);
            //Assert          
            Assert.Equal(((ObjectResult)actionResult.Result).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }
    }
}
