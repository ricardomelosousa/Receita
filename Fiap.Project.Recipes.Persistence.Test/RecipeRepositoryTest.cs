using Fiap.Project.Recipes.Application.Interfaces;
using Fiap.Project.Recipes.Domain.Models;
using Fiap.Project.Recipes.Persistence.Repositories;
using Moq;
using Xunit;

namespace Fiap.Project.Recipes.Persistence.Test
{
    public class RecipeRepositoryTest
    {
       
        [Fact]
        public void Test_Insert_Recipe()
        {
            var recipe = new Recipe() { CategoryId = 2, Descricao = "Pudim", DataInclusao = System.DateTime.Now, Titulo = "Pudim de leite" };

            var repo = new RecipeRepository(DBInMemoryConfigure.GetContextInMemory());

            //Criar as intefaces de repositorio e service em domain para iniciar teste corretamente
            var mock = new Mock<IRecipeRepository>();

           


        }
    }
}