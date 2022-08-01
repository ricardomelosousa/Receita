using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Recipes.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public string GenerateNewPassword(string password)
        {
            //logic here
            if (password == null)
                throw new BusinessRuleException("Senha invalida!");
            return password;

        }
        public bool CheckPasswordRequeriments(string password)
        {
            //Logic here
            if (password == null)
                throw new BusinessRuleException("Requerimento de senha insuficiente, por favor, tente outra sequência.");
            return true;
        }

    }
}
