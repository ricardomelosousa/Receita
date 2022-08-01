namespace Project.Recipes.Application.Interfaces.Base
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        Task<int> Add(TEntity obj);
        Task<TEntity> GetById(int id);
        Task<TEntity> FindBy(Func<TEntity, bool> predicate, bool @readonly);
        Task<IQueryable<TEntity>> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
