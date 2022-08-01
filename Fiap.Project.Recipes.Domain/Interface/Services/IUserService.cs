using Project.Recipes.Domain.Interface.Services.Base;
using Project.Recipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Recipes.Domain.Interface.Services
{
    public interface IUserService : IServiceBase<User>
    {
        User Login(string login, string Password);
    }
}
