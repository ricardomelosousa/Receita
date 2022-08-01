using System.ComponentModel.DataAnnotations;

namespace Project.Recipes.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }

       

    }
}
