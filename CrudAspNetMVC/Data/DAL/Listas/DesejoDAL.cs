using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo.Listas;
using Microsoft.EntityFrameworkCore;

namespace CrudAspNetMVC.Data.DAL.Listas
{
    public class DesejoDAL
    { 

        private IESContext _context;

        public DesejoDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<ListaDesejo> PegarDesejoPorNome()
        {
            return _context.Desejos.OrderBy(b => b.Produto.ProdutoNome);
        }

        public async Task<ListaDesejo> PegarDesejoPorId(long id)
        {
            return await _context.Desejos.FindAsync(id);
        }

        public async Task<ListaDesejo> RegistrarDesejo(ListaDesejo desejo)
        {
            if (desejo.DesejoId == null)
            {
                _context.Desejos.Add(desejo);
            }
            else
            {
                _context.Update(desejo);
            }
            await _context.SaveChangesAsync();
            return desejo;
        }

        public async Task<ListaDesejo> DeletarDesejoPorId(long id)
        {
            ListaDesejo desejo = await PegarDesejoPorId(id);
            _context.Desejos.Remove(desejo);
            await _context.SaveChangesAsync();
            return desejo;
        }
    }
}
