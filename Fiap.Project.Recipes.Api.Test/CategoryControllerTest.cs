using Microsoft.AspNetCore.Mvc;
using Moq;
using Project.Recipes.Api.Controllers;
using Project.Recipes.Application.Interfaces;
using Project.Recipes.Domain.Models;
using Xunit;

namespace Project.Recipes.Api.Test
{
    public class CategoryControllerTest
    {
        private readonly Mock<ICategoryAppService> _CategoryServiceMock;

        public CategoryControllerTest()
        {
            _CategoryServiceMock = new Mock<ICategoryAppService>();
        }

        [Fact]
        public async void Get_Category_Por_Id()
        {
            //Arrange
            int CategoryId = 2;
            var Category = new Category() { Id = 2, Descricao = "As melhores sobremesas", Titulo = "Sobremesas" };
            _CategoryServiceMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(Category);
            //Act
            var CategoryController = new CategoriesController(_CategoryServiceMock.Object);
            var actionResult = await CategoryController.Get(CategoryId);

            //Assert      
            Assert.Equal(actionResult.Value.Id, CategoryId);

        }

        [Fact]
        public void Test_Insert_Category()
        {
            //Arrange
            int CategoryId = 2;
            var Category = new Category() { Id = 2, Descricao = "As melhores sobremesas", Titulo = "Sobremesas" };
            _CategoryServiceMock.Setup(x => x.Add(It.IsAny<Category>()));
            //Act
            var CategoryController = new CategoriesController(_CategoryServiceMock.Object);
            var actionResult = CategoryController.Insert(Category);

            //Assert          
            Assert.Equal(((ObjectResult)actionResult.Result).StatusCode, (int)System.Net.HttpStatusCode.Created);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as Category).Id, CategoryId);
        }

        [Fact]
        public async void Test_Delete_Category()
        {
            //Arrange
            int CategoryId = 2;
            var Category = new Category() { Id = 2, Descricao = "As melhores sobremesas", Titulo = "Sobremesas" };
            _CategoryServiceMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(Category);
            //Act
            var CategoryController = new CategoriesController(_CategoryServiceMock.Object);
            var actionResult = CategoryController.Get(CategoryId);
            var actionResultDelete = await CategoryController.Delete(CategoryId);
            //Assert          
            Assert.Equal(((NoContentResult)actionResultDelete).StatusCode, (int)System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public void Test_Update_Category()
        {
            //Arrange
            var Category = new Category() { Id = 2, Descricao = "As melhores sobremesas do mundo", Titulo = "Sobremesas" };
            _CategoryServiceMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(Category);
            //Act
            var CategoryController = new CategoriesController(_CategoryServiceMock.Object);
            var actionResult = CategoryController.Update(Category);
            //Assert          
            Assert.Equal(((ObjectResult)actionResult.Result).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }
    }
}