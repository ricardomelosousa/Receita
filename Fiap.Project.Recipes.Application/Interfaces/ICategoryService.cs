using Fiap.Project.Recipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Application.Interfaces
{
    public interface ICategoryService
    {
        void Insert(Category Category);
        Category Get(int id);
        void Update(Category Category);
        void Delete(int id);
        IEnumerable<Category> GetAll();
    }
}
