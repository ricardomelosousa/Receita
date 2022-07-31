using Fiap.Project.Recipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Application.Interfaces
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAll();
        void Insert(Recipe Recipe);
        Recipe Get(int id);
        void Update(Recipe Recipe);
        void Delete(int id);
        IEnumerable<Recipe> GetAll(int Category);
    }
}
