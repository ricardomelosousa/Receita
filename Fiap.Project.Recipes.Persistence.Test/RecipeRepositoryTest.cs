using Moq;
using Project.Recipes.Domain.Interface.Repository;
using Project.Recipes.Domain.Models;
using Project.Recipes.Persistence.Repositories;
using Xunit;

namespace Project.Recipes.Persistence.Test
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