using System;

namespace Project.Recipes.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
