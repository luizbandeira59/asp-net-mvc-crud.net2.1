﻿// <auto-generated />
using System;
using CrudAspNetMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrudAspNetMVC.Migrations
{
    [DbContext(typeof(IESContext))]
    [Migration("20200614023513_InitialM1")]
    partial class InitialM1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Modelo.Cadastros.Categoria", b =>
                {
                    b.Property<long?>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CatNome");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Modelo.Cadastros.DespesaDir", b =>
                {
                    b.Property<long?>("DespesaDirId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CategoriaId");

                    b.Property<DateTime>("DespDirData");

                    b.Property<double>("DespDirValor");

                    b.Property<long?>("FormaId");

                    b.Property<long?>("ProdutoId");

                    b.Property<int>("Status");

                    b.HasKey("DespesaDirId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("DespesaDir");
                });

            modelBuilder.Entity("Modelo.Cadastros.DespesaFixa", b =>
                {
                    b.Property<long?>("DespesaFixId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CategoriaId");

                    b.Property<DateTime>("DespFixData");

                    b.Property<double>("DespFixValor");

                    b.Property<long?>("FormaId");

                    b.Property<long?>("ProdutoId");

                    b.Property<int>("Status");

                    b.HasKey("DespesaFixId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("DespesaFixa");
                });

            modelBuilder.Entity("Modelo.Cadastros.FormaPagamento", b =>
                {
                    b.Property<long?>("FormaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FormaNome");

                    b.HasKey("FormaId");

                    b.ToTable("Formas");
                });

            modelBuilder.Entity("Modelo.Cadastros.ListaDesejos", b =>
                {
                    b.Property<long?>("DesejoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CategoriaId");

                    b.Property<DateTime>("DesejoData");

                    b.Property<double>("DesejoValor");

                    b.Property<long?>("FormaId");

                    b.Property<long?>("ProdutoId");

                    b.Property<int>("Status");

                    b.HasKey("DesejoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Desejos");
                });

            modelBuilder.Entity("Modelo.Cadastros.Mercado", b =>
                {
                    b.Property<long?>("MercadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CategoriaId");

                    b.Property<long?>("FormaId");

                    b.Property<DateTime>("MercadoData");

                    b.Property<double>("MercadoValor");

                    b.Property<long?>("ProdutoId");

                    b.Property<int>("StatusCompra");

                    b.HasKey("MercadoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Mercado");
                });

            modelBuilder.Entity("Modelo.Cadastros.Produto", b =>
                {
                    b.Property<long?>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CategoriaId");

                    b.Property<string>("ProdutoDescricao");

                    b.Property<string>("ProdutoNome");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Modelo.Cadastros.DespesaDir", b =>
                {
                    b.HasOne("Modelo.Cadastros.Categoria", "Categoria")
                        .WithMany("DespesaDiretas")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("Modelo.Cadastros.FormaPagamento", "FormaPagamento")
                        .WithMany("DespesasDiretas")
                        .HasForeignKey("FormaId");

                    b.HasOne("Modelo.Cadastros.Produto", "Produto")
                        .WithMany("DespesasDiretas")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("Modelo.Cadastros.DespesaFixa", b =>
                {
                    b.HasOne("Modelo.Cadastros.Categoria", "Categoria")
                        .WithMany("DespesasFixas")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("Modelo.Cadastros.FormaPagamento", "FormaPagamento")
                        .WithMany("DespesasFixas")
                        .HasForeignKey("FormaId");

                    b.HasOne("Modelo.Cadastros.Produto", "Produto")
                        .WithMany("DespesasFixas")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("Modelo.Cadastros.ListaDesejos", b =>
                {
                    b.HasOne("Modelo.Cadastros.Categoria", "Categoria")
                        .WithMany("ListaDesejos")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("Modelo.Cadastros.FormaPagamento", "FormaPagamento")
                        .WithMany("ListaDesejos")
                        .HasForeignKey("FormaId");

                    b.HasOne("Modelo.Cadastros.Produto", "Produto")
                        .WithMany("ListaDesejos")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("Modelo.Cadastros.Mercado", b =>
                {
                    b.HasOne("Modelo.Cadastros.Categoria", "Categoria")
                        .WithMany("Mercados")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("Modelo.Cadastros.FormaPagamento", "FormaPagamento")
                        .WithMany("Mercados")
                        .HasForeignKey("FormaId");

                    b.HasOne("Modelo.Cadastros.Produto", "Produto")
                        .WithMany("Mercados")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("Modelo.Cadastros.Produto", b =>
                {
                    b.HasOne("Modelo.Cadastros.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId");
                });
#pragma warning restore 612, 618
        }
    }
}