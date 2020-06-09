using CrudAspNetMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspNetMVC.Models
{
    public class IESDbInit
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Categorias.Any())
            {
                return;
            }

            var categorias = new Categoria[]
            {
                new Categoria { CatNome = "Acessórios" },
                new Categoria { CatNome = "Bônus" },
                new Categoria { CatNome = "Cheque Especial" },
                new Categoria { CatNome = "Comidas e Bebidas" },
                new Categoria { CatNome = "Contas Residenciais" },
                new Categoria { CatNome = "Crediário" },
                new Categoria { CatNome = "Crédito Consignado" },
                new Categoria { CatNome = "Cuidados Pessoais" },
                new Categoria { CatNome = "Despesas com Trabalho" },
                new Categoria { CatNome = "Educação" },
                new Categoria { CatNome = "Eletrônico" },
                new Categoria { CatNome = "Eletrodoméstico" },
                new Categoria { CatNome = "Empréstimo" },
                new Categoria { CatNome = "Encargos" },
                new Categoria { CatNome = "Família e Filhos" },
                new Categoria { CatNome = "FGTS" },
                new Categoria { CatNome = "Imposto" },
                new Categoria { CatNome = "Investimento" },
                new Categoria { CatNome = "Jogo Eletrônico" },
                new Categoria { CatNome = "Juros" },
                new Categoria { CatNome = "Lazer e Hobbie" },
                new Categoria { CatNome = "Mercado" },
                new Categoria { CatNome = "Moradia" },
                new Categoria { CatNome = "Outras Rendas" },
                new Categoria { CatNome = "Outros Gastos" },
                new Categoria { CatNome = "Mascote" },
                new Categoria { CatNome = "Presente ou Doação" },
                new Categoria { CatNome = "Rendimentos" },
                new Categoria { CatNome = "Resgate" },
                new Categoria { CatNome = "Salário" },
                new Categoria { CatNome = "Saques" },
                new Categoria { CatNome = "Saúde" },
                new Categoria { CatNome = "Serviços" },
                new Categoria { CatNome = "Telefonia / Internet / TV" },
                new Categoria { CatNome = "Transferência" },
                new Categoria { CatNome = "Transporte" },
                new Categoria { CatNome = "Vestuário" },
                new Categoria { CatNome = "Compras" },
                new Categoria { CatNome = "Ciência da Computação"},
                new Categoria { CatNome = "Ciência de Alimentos"}
            };

            foreach (Categoria c in categorias)
            {
                context.Categorias.Add(c);
            }

            var produtos = new Produto[]
            {            
                new Produto { ProdutoNome = "CELULAR A50", ProdutoDescricao = "CELULAR SAMSUNG A50 128GB" },
                new Produto { ProdutoNome = "MONITOR 22 DELL", ProdutoDescricao = "MONITOR DELL P2219H FULLHD" },
                new Produto { ProdutoNome = "TV LED 4K SAMSUNG 50", ProdutoDescricao = "TV LED 4K SANSUMG RU7100 50 POLEDADAS" },
                new Produto { ProdutoNome = "BOLSA GRANDE FEMININA DE COURO", ProdutoDescricao = "BOLSA GRANDE FEMININA DE COURO MACIO COM 2 ALÇAS" },
                new Produto { ProdutoNome = "XIAOMI SMARTWATCH AMAZIFIT BIP", ProdutoDescricao = "AMAZIFIT BIP XIAOMI A1608, PRETO" },
                new Produto { ProdutoNome = "GAMEPAD 5X1 PARA CELULAR", ProdutoDescricao = " SUPORTE PARA CELULAR GAMEPAD 5 EM 1" },
                new Produto { ProdutoNome = "XIAOMI MIBAND 4", ProdutoDescricao = "PULSEIRA XIAOMI MIBAND 4 PRETO" },
                new Produto { ProdutoNome = "TAPETE DE SISAL 2X3M", ProdutoDescricao = "TAPETE SISAL 2X3M" },
                new Produto { ProdutoNome = "PANELA PRESSÃO 10L", ProdutoDescricao = "PANELA PRESSÃO 10L EIRILAR TRAVA EXTERNA" },
                new Produto { ProdutoNome = "SUPORTE DE TABLET", ProdutoDescricao = "SUPORTE DE MESA PARA TABLET" }

            };

            foreach (Produto p in produtos)
            {
                context.Produtos.Add(p);
            }

            context.SaveChanges();
        }
    }
}
