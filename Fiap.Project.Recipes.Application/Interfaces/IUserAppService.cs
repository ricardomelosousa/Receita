using Project.Recipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Recipes.Application.Interfaces
{
    public interface IUserAppService : IAppServiceBase<User>
    {
        User Login(string login, string Password);
        string GenerateJwtToken(User User);
    }
}
