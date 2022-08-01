using Project.Recipes.Domain.Interface.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Recipes.Application.Services.Base
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public virtual async Task<int> Add(TEntity obj)
        {
            return await _serviceBase.Add(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public virtual async Task<TEntity> FindBy(Func<TEntity, bool> predicate, bool @readonly)
        {
            return await _serviceBase.FindBy(predicate, @readonly);
        }

        public virtual async Task<IQueryable<TEntity>> GetAll()
        {
            return await _serviceBase.GetAll();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _serviceBase.GetById(id);
        }

        public virtual void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public virtual void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public virtual async Task<IQueryable<TEntity>> GetAllByParamenter(Func<TEntity, bool> predicate, bool @readonly)
        {
            return await _serviceBase.GetAllByParamenter(predicate, @readonly);
        }

    }
}
