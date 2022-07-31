using Fiap.Project.Recipes.Api.Controllers;
using Fiap.Project.Recipes.Application.Interfaces;
using Fiap.Project.Recipes.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Fiap.Project.Recipes.Api.Test
{
    public class CategoryControllerTest
    {
        private readonly Mock<ICategoryService> _CategoryServiceMock;

        public CategoryControllerTest()
        {
            _CategoryServiceMock = new Mock<ICategoryService>();
        }

        [Fact]
        public void Get_Category_Por_Id()
        {
            //Arrange
            int CategoryId = 2;
            var Category = new Category() { Id = 2, Descricao = "As melhores sobremesas", Titulo = "Sobremesas" };
            _CategoryServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Category);
            //Act
            var CategoryController = new CategoriesController(_CategoryServiceMock.Object);
            var actionResult = CategoryController.Get(CategoryId);

            //Assert      
            Assert.Equal(actionResult.Value.Id, CategoryId);

        }

        [Fact]
        public void Test_Insert_Category()
        {
            //Arrange
            int CategoryId = 2;
            var Category = new Category() { Id = 2, Descricao = "As melhores sobremesas", Titulo = "Sobremesas" };
            _CategoryServiceMock.Setup(x => x.Insert(It.IsAny<Category>()));
            //Act
            var CategoryController = new CategoriesController(_CategoryServiceMock.Object);
            var actionResult = CategoryController.Insert(Category);

            //Assert          
            Assert.Equal(((ObjectResult)actionResult.Result).StatusCode, (int)System.Net.HttpStatusCode.Created);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as Category).Id, CategoryId);
        }

        [Fact]
        public void Test_Delete_Category()
        {
            //Arrange
            int CategoryId = 2;
            var Category = new Category() { Id = 2, Descricao = "As melhores sobremesas", Titulo = "Sobremesas" };
            _CategoryServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Category);
            //Act
            var CategoryController = new CategoriesController(_CategoryServiceMock.Object);
            var actionResult = CategoryController.Get(CategoryId);
            var actionResultDelete = CategoryController.Delete(CategoryId);
            //Assert          
            Assert.Equal(((NoContentResult)actionResultDelete).StatusCode, (int)System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public void Test_Update_Category()
        {
            //Arrange
            var Category = new Category() { Id = 2, Descricao = "As melhores sobremesas do mundo", Titulo = "Sobremesas" };
            _CategoryServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Category);
            //Act
            var CategoryController = new CategoriesController(_CategoryServiceMock.Object);
            var actionResult = CategoryController.Update(Category);
            //Assert          
            Assert.Equal(((ObjectResult)actionResult.Result).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }
    }
}