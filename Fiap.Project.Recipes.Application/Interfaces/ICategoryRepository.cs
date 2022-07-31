using Fiap.Project.Recipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Application.Interfaces
{
    public interface ICategoryRepository
    {
        void Insert(Category Category);
        void Delete(int id);
        Category Get(int id);
        void Update(Category Category);
        IEnumerable<Category> GetAll();
    }
}
