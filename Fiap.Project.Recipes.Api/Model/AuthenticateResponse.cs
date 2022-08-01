using Project.Recipes.Domain.Models;

namespace Project.Recipes.Api.Model
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }     
        public string Email { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Login = user.Login;
            Email = user.Email;
            Token = token;
            Name = user.Name;
        }
    }
}
