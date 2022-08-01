using System.ComponentModel.DataAnnotations;

namespace Project.Recipes.Web.Model
{
    public class LoginViewModel
    {
       
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
