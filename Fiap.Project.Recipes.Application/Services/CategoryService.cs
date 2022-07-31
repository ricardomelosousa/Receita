using Fiap.Project.Recipes.Application.Interfaces;
using Fiap.Project.Recipes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public void Update(Category Category)
        {
            _repository.Update(Category);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Insert(Category Category)
        {
            _repository.Insert(Category);
        }

        public Category Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
