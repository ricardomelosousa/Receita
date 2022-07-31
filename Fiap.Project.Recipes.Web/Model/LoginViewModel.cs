using System.ComponentModel.DataAnnotations;

namespace Fiap.Project.Recipes.Web.Model
{
    public class LoginViewModel
    {
       
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}
