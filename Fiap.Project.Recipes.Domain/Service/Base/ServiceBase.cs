using Project.Recipes.Domain.Interface.Repository.Base;
using Project.Recipes.Domain.Interface.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Recipes.Domain.Service.Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual async Task<int> Add(TEntity obj) => await _repository.Add(obj);
        public void Dispose() => _repository.Dispose();
        public virtual async Task<TEntity> FindBy(Func<TEntity, bool> predicate, bool @readonly = false)
        => await _repository.FindBy(predicate, @readonly);
        public virtual async Task<IQueryable<TEntity>> GetAll() => await _repository.GetAll();
        public virtual async Task<TEntity> GetById(int id) => await _repository.GetById(id);
        public void Remove(TEntity id) => _repository.Remove(id);
        public async Task<int> SaveChanges() => await _repository.SaveChanges();
        public void Update(TEntity obj) => _repository.Update(obj);
        public Task<IQueryable<TEntity>> GetAllByParamenter(Func<TEntity, bool> predicate, bool @readonly)
             => _repository.GetAllByParamenter(predicate, @readonly);
    }
}
