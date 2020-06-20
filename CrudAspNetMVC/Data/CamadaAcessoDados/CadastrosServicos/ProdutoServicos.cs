using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo.CadastrosBLL;
using Microsoft.EntityFrameworkCore;
using CrudAspNetMVC.Data.CamadaAcessoDados.Erros;


//Data Acess Layer - Camada de acesso a dados - DAL - responsável por realizar o acesso e a persistência aos dados fazendo a comunicação entre a BLL e UI;.
//BLL – Camada de Regra de negócios(Business Logic Layer); UI – Camada de Apresentação(User Interface)

namespace CrudAspNetMVC.Data.CamadaAcessoDados.Cadastros
{
    public class ProdutoServicos
    {
        //INSTANCIANDO A CONTEXT PARA INJEÇÃO DE DEPENDÊNCIA
        private ControleContext _context;

        //MÉTODO CONSTRUTOR
        public ProdutoServicos(ControleContext context)
        {
            _context = context;
        }

        //IQueryable<> é específico para o LINQ.Um IQueryable<> também é 
        //derivado de um IEnumerable<T> e admite lazy loading permitindo uma melhor otimização 
        //de uma consulta.Ou seja, apenas os elementos realmente necessários para uma determinada 
        //operação são retornados na consulta para futura análise.
        public IQueryable<Produto> PegarProdutoPorNome()
        {
            return _context.Produtos.Include(i => i.Categoria).Include(i => i.FormaPagamento).Include(i => i.StatusCompra).OrderBy(p => p.ProdutoNome);
        }

        //MÉTODO PARA BUSCAR UM PRODUTO DE UMA LISTA DE PRODUTOS POR ID(KEY)
        //Você pode usar o método Include para especificar os dados relacionados a serem incluídos nos resultados da consulta.
        public async Task<Produto> PegarProdutoPorId(long id)
        {
            var produto = await _context.Produtos.SingleOrDefaultAsync(m => m.ProdutoId == id);
            _context.Categorias.Where(i => produto.CategoriaId == i.CategoriaId).Load();
            _context.Formas.Where(i => produto.FormaId == i.FormaId).Load();
            _context.Status.Where(i => produto.StatusId == i.StatusId).Load();
            return produto;
        }

        public async Task Atualizar(Produto produto)
        {
            if (!_context.Produtos.Any(x => x.ProdutoId == produto.ProdutoId))
            {
                throw new NotFoundException("Produto não encontrado!");
            }
            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<Produto> CriarProduto(Produto produto)
        {
            if (produto.ProdutoId == null)
            {
                _context.Produtos.Add(produto);
            }
            else
            {
                _context.Update(produto);
            }
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> DeletarProdutoPorId(long id)
        {
            Produto produto = await PegarProdutoPorId(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

    }
}
