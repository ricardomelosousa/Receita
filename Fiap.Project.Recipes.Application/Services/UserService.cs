using Fiap.Project.Recipes.Application.Interfaces;
using Fiap.Project.Recipes.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap.Project.Recipes.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository UserRepository, IConfiguration configuration)
        {
            _UserRepository = UserRepository;
            _configuration = configuration;
        }       

        public User Login(string login, string senha)
        {
            return _UserRepository.Login(login, senha);
        }

        public User Get(int UserId)
        {
            return _UserRepository.Get(UserId);
        }

        public int SalvarUser(User User)
        {
            return _UserRepository.SalvarUser(User);
        }

        public string GenerateJwtToken(User User)
        {
            try
            {
                var secret = _configuration["AppSettings:Secret"];
                // generate token that is valid for 7 days
                var tokenHandler = new JwtSecurityTokenHandler();
                //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var key = Encoding.ASCII.GetBytes(secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", User.Id.ToString()),
                                                 new Claim(ClaimTypes.Name, User.Nome.ToString()),
                                                 new Claim(ClaimTypes.Role, User.Role.ToString())}),
                    Expires = DateTime.UtcNow.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
