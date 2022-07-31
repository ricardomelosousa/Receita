using Fiap.Project.Recipes.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Project.Recipes.Persistence.Test
{
    public static class DBInMemoryConfigure
    {
        public static SqlDataContext GetContextInMemory()
        {
            DbContextOptions<SqlDataContext> options;
            DbContextOptionsBuilder<SqlDataContext> builder = new DbContextOptionsBuilder<SqlDataContext>();
            //builder.UseInMemoryDatabase("TestOsDB");
            options = builder.Options;
            var context = new SqlDataContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }
    }
}
