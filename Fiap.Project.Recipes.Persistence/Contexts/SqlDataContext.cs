using Fiap.Project.Recipes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fiap.Project.Recipes.Persistence.Contexts
{
    public class SqlDataContext : DbContext
    {
        public SqlDataContext(DbContextOptions<SqlDataContext> options) : base(options)
        {
        }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Nome = "Administrador",
                Email = "admin@admin",
                Login = "admin",
                Senha = "123456",
                Role = "Administrador"
            });

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category() { Id = 1, Titulo = "Doces e sobremesas", Descricao = "Doces e sobremesas" },
                    new Category() { Id = 2, Titulo = "Bolos e tortas", Descricao = "Bolos e tortas" },
                    new Category() { Id = 3, Titulo = "Massas", Descricao = "Massas" },
                    new Category() { Id = 4, Titulo = "Carnes", Descricao = "Carnes" },
                    new Category() { Id = 5, Titulo = "Aves", Descricao = "Aves" }
                );

            modelBuilder.Entity<Recipe>()
                .HasData(
                    new Recipe()
                    {
                        Id = 1,
                        Titulo = "Cookies de aveia",
                        Descricao = "Deliciosos cookies",
                        Ingredientes = "ingredientes do cookie",
                        Preparo = "preparo do cookie",
                        Tags = "cookie;aveia;",
                        CategoryId = 1,
                        DataInclusao = DateTime.Now
                    },
                    new Recipe()
                    {
                        Id= 2,
                        Titulo = "Pudim de leite",
                        Descricao = "famoso pudim",
                        Ingredientes = "ingrdientes do pudim",
                        Preparo = "preparo do pudim",
                        Tags = "pudim;leite;",
                        CategoryId = 1,
                        DataInclusao = DateTime.Now
                    },
                    new Recipe()
                    {
                        Id = 3,
                        Titulo = "Bolo de chocolate",
                        Descricao = "irresistível bolo de chocolate",
                        Ingredientes = "ingredientes do bolo",
                        Preparo = "preparo do bolo",
                        Tags = "bolo;chocolate;",
                        CategoryId = 2,
                        DataInclusao = DateTime.Now
                    },
                    new Recipe()
                    {
                        Id =4,
                        Titulo = "Torta de limão",
                        Descricao = "deliciosa torta",
                        Ingredientes = "ingredientes da torta",
                        Preparo = "preparo da torta",
                        Tags = "torta;limao;",
                        CategoryId = 2,
                        DataInclusao = DateTime.Now
                    },
                    new Recipe()
                    { 
                        Id =5,
                        Titulo = "Carbonara",
                        Descricao = "Massa clássica",
                        Ingredientes = "ingredientes do carbonara",
                        Preparo = "preparo do carbonara",
                        Tags = "carbonara;bacon;",
                        CategoryId = 3,
                        DataInclusao = DateTime.Now
                    },
                    new Recipe()
                    {
                        Id=6,
                        Titulo = "Lasanha",
                        Descricao = "almoço de domingo",
                        Ingredientes = "ingredientes da lasanha",
                        Preparo = "preparo da lasanha",
                        Tags = "lasanha;queijo;",
                        CategoryId = 3,
                        DataInclusao = DateTime.Now
                    },
                    new Recipe()
                    {
                        Id=7,
                        Titulo = "Bolo de carne",
                        Descricao = "delicioso",
                        Ingredientes = "ingredientes do bolode carne",
                        Preparo = "preparo do bolo de carne",
                        Tags = "carne;queijo;presunto;",
                        CategoryId = 4,
                        DataInclusao = DateTime.Now
                    },
                    new Recipe()
                    {
                        Id=8,
                        Titulo = "Carne de panela",
                        Descricao = "tradicional carne de panela",
                        Ingredientes = "ingredientes de carne de panela",
                        Preparo = "preparo de carne de panela",
                        Tags = "",
                        CategoryId = 4,
                        DataInclusao = DateTime.Now
                    },
                    new Recipe()
                    {
                        Id =9,
                        Titulo = "Strogonoff de frango",
                        Descricao = "Strogonoff de frango fácil",
                        Ingredientes = "ingredientes de strogonoff de frango",
                        Preparo = "preparo de strogonoff de frango",
                        Tags = "",
                        CategoryId = 5,
                        DataInclusao = DateTime.Now
                    },
                    new Recipe()
                    {
                        Id=10,
                        Titulo = "Medalhão de frango com bacon",
                        Descricao = "Medalhão de frango com bacon irresistível",
                        Ingredientes = "ingredientes de Medalhão de frango com bacon",
                        Preparo = "preparo de Medalhão de frango com bacon",
                        Tags = "frango;bacon;",
                        CategoryId = 5,
                        DataInclusao = DateTime.Now
                    }
                );
        }
     
    }
}
