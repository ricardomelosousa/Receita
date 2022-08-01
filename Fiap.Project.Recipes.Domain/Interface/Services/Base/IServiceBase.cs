using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Recipes.Domain.Interface.Services.Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<int> Add(TEntity obj);
        Task<TEntity> GetById(int id);
        Task<TEntity> FindBy(Func<TEntity, bool> predicate, bool @readonly);
        Task<IQueryable<TEntity>> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity id);
        Task<int> SaveChanges();
        void Dispose();
        Task<IQueryable<TEntity>> GetAllByParamenter(Func<TEntity, bool> predicate, bool @readonly);
    }
}
