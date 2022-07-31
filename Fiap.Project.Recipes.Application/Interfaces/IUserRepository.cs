using Fiap.Project.Recipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Application.Interfaces
{
    public interface IUserRepository
    {
        User Get(int UserId);
        User Login(string login, string senha);
        int SalvarUser(User User);
    }
}
