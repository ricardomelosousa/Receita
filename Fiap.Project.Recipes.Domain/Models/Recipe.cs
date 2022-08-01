using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Recipes.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [Required]
        public string Ingredientes { get; set; }
        [Required]
        public string Preparo { get; set; }
        public string Imagem { get; set; }
        public string Tags { get; set; }
        public int CategoryId { get; set; }
        public virtual Category CategoryRecipe { get; set; }
        public DateTime DataInclusao { get; set; }


        public void RecipeHaveContainIngredientsForCategory()
        {
            if (string.IsNullOrEmpty(Ingredientes) || CategoryId == 0)
            {
                throw new BusinessRuleException("Informe os ingredientes corretos da receita.");
            }

        }
        public void RecipeHaveContainIngredients() 
        {
            if (string.IsNullOrEmpty(Ingredientes))
                throw new BusinessRuleException("Informe os ingredientes da receita.");
        
        }

    }
}
