using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;

namespace CrudAspNetMVC.Data.DAL.Cadastros
{
    public class ProdutoDAL
    {
        private IESContext _context;

        public ProdutoDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Produto> PegarProdutoPorNome()
        {
            return _context.Produtos.Include(i => i.Categoria).OrderBy(p => p.ProdutoNome);
        }

        public async Task<Produto> PegarProdutoPorId(long id)
        {
            var produto = await _context.Produtos.SingleOrDefaultAsync(m => m.ProdutoId == id);
            _context.Categorias.Where(i => produto.CategoriaId == i.CategoriaId).Load(); 
            return produto;
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
