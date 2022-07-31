using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }

       

    }
}
