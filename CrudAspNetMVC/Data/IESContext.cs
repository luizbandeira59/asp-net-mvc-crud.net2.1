using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo.Cadastros;
using Modelo.Cadastros.Enums;

namespace CrudAspNetMVC.Data
{
    public class IESContext : DbContext
    {

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<FormaPagamento> Formas { get; set; }
        public DbSet<ListaDesejos> Desejos { get; set; }      

        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Categoria>().ToTable("Categoria");
       //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IESCrudMVC;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

       
    }
}

