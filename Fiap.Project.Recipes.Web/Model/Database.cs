using Fiap.Project.Recipes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Web.Model
{
    public class Database : DbContext
    {

        
        protected const string ConnectionString = "";
        public Database()
        {

        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .ToTable("Category");

            modelBuilder.Entity<Category>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Category>()
                .Property(x => x.Titulo)               
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(x => x.Descricao)
                .HasMaxLength(50)
                .IsRequired();




            modelBuilder.Entity<Recipe>()
             .ToTable("Recipe");

            modelBuilder.Entity<Recipe>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Recipe>()
                .Property(x => x.Titulo)
                .IsRequired();

            modelBuilder.Entity<Recipe>()
                .Property(x => x.Descricao)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Recipe>()
           .Property(x => x.Titulo)
           .HasMaxLength(50)
           .IsRequired();

            modelBuilder.Entity<Recipe>()
           .Property(x => x.Preparo)
           .HasMaxLength(50)
           .IsRequired();

            modelBuilder.Entity<Recipe>()
          .Property(x => x.Imagem)          
          .IsRequired();

            modelBuilder.Entity<Recipe>()
          .Property(x => x.CategoryId);
         




        }




    }
}
