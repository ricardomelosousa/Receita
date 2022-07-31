using Fiap.Project.Recipes.Domain.Models;

namespace Fiap.Project.Recipes.Api.Model
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }     
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Login = user.Login;
            Email = user.Email;
            Token = token;
            Nome = user.Nome;
        }
    }
}
