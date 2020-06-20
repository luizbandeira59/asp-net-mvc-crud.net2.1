using CrudAspNetMVC.Models.Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modelo.CadastrosBLL;
using Modelo.ListasBLL;

namespace CrudAspNetMVC.Data
{
    public class ControleContext : IdentityDbContext<UsuarioApp>
    {

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<DespesaDir> DespesaDiretas { get; set; }
        public DbSet<DespesaFixa> DespesasFixas { get; set; }
        public DbSet<FormaPagamento> Formas { get; set; }
        public DbSet<ListaDesejo> Desejos { get; set; }
        public DbSet<ListaMercado> Mercados { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<StatusCompra> Status { get; set; }



        public ControleContext(DbContextOptions<ControleContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FormaPagamento>().ToTable("FormaPagamento");
            modelBuilder.Entity<PagamentoProduto>()
                .HasKey(cd => new { cd.ProdutoId, cd.FormaId });

            modelBuilder.Entity<PagamentoProduto>()
                .HasOne(c => c.Produto)
                .WithMany(cd => cd.PagamentoProdutos)
                .HasForeignKey(c => c.ProdutoId);

            modelBuilder.Entity<PagamentoProduto>()
                .HasOne(d => d.FormaPagamento)
                .WithMany(cd => cd.PagamentoProdutos)
                .HasForeignKey(d => d.FormaId);



            modelBuilder.Entity<ProdutoStatus>()
              .HasKey(cd => new { cd.ProdutoId, cd.StatusId });

            modelBuilder.Entity<ProdutoStatus>()
                .HasOne(c => c.Produto)
                .WithMany(cd => cd.ProdutosStatuss)
                .HasForeignKey(c => c.ProdutoId);

            modelBuilder.Entity<ProdutoStatus>()
                .HasOne(d => d.StatusCompra)
                .WithMany(cd => cd.ProdutosStatuss)
                .HasForeignKey(d => d.StatusId);


        }

        /*
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Categoria>().ToTable("Categoria");
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IESCrudMVC;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        */

    }
}

