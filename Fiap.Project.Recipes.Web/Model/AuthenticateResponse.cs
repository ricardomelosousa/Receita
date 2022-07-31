using Fiap.Project.Recipes.Domain.Models;

namespace Fiap.Project.Recipes.Web.Model
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }     
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }      
    }
}
