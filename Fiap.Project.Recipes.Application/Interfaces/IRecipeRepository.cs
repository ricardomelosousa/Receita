using Fiap.Project.Recipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Application.Interfaces
{
    public interface IRecipeRepository
    {
        void Insert(Recipe Recipe);
        void Delete(int id);
        Recipe Get(int id);
        void Update(Recipe Recipe);
        IEnumerable<Recipe> GetAll();
        IEnumerable<Recipe> GetAll(int Category);
    }
}
