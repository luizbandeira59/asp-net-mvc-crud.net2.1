using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;

namespace CrudAspNetMVC.Data.DAL.Cadastros
{
    public class CategoriaDAL
    {
        private IESContext _context;

        public CategoriaDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Categoria> PegarCategoriasPorNome()
        {
            return _context.Categorias.OrderBy(c => c.CatNome);
        }

        public async Task<Categoria> PegarCategoriaPorId(long id)
        {
            return await _context.Categorias.Include(p => p.Produtos).Include(l => l.ListaDesejos).Include(m => m.Mercados).SingleOrDefaultAsync(m => m.CategoriaId == id);
        }

        public async Task<Categoria> CriarCategoria(Categoria categoria)
        {
            if (categoria.CategoriaId == null)
            {
                _context.Categorias.Add(categoria);
            }
            else
            {
                _context.Update(categoria);
            }
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> DeletarCategoriaPorId(long id)
        {
            Categoria categoria = await PegarCategoriaPorId(id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
    }
}
