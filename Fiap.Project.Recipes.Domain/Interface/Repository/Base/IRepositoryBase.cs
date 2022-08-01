using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Recipes.Domain.Interface.Repository.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
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
