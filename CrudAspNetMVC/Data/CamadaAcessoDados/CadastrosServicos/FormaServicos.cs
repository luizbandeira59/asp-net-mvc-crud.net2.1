using System.Linq;
using System.Threading.Tasks;
using Modelo.CadastrosBLL;
using Microsoft.EntityFrameworkCore;

//Data Acess Layer - Camada de acesso a dados - DAL - responsável por realizar o acesso e a persistência aos dados fazendo a comunicação entre a BLL e UI;.
//BLL – Camada de Regra de negócios(Business Logic Layer); UI – Camada de Apresentação(User Interface)

namespace CrudAspNetMVC.Data.CamadaAcessoDados.Cadastros
{
    public class FormaServicos
    {
        //INSTANCIANDO A CONTEXT PARA INJEÇÃO DE DEPENDÊNCIA
        private ControleContext _context;

        //MÉTODO CONSTRUTOR
        public FormaServicos(ControleContext context)
        {
            _context = context;
        }

        //IQueryable<> é específico para o LINQ.Um IQueryable<> também é 
        //derivado de um IEnumerable<T> e admite lazy loading permitindo uma melhor otimização 
        //de uma consulta.Ou seja, apenas os elementos realmente necessários para uma determinada 
        //operação são retornados na consulta para futura análise.
        public IQueryable<FormaPagamento> PegarFormaPorNome()
        {
            return _context.Formas.OrderBy(c => c.FormaNome);
        }

        public async Task<FormaPagamento> PegarFormaPorId(long id)
        {
            return await _context.Formas.Include(p => p.Produtos)
                .Include(l => l.ListaDesejos).Include(m => m.Mercados)
                .SingleOrDefaultAsync(m => m.FormaId == id);
        }

        public async Task<FormaPagamento> CriarFormaPagamento(FormaPagamento forma)
        {
            if (forma.FormaId == null)
            {
                _context.Formas.Add(forma);
            }
            else
            {
                _context.Update(forma);
            }
            await _context.SaveChangesAsync();
            return forma;
        }

        public async Task<FormaPagamento> DeletarFormaPorId(long id)
        {
            FormaPagamento forma = await PegarFormaPorId(id);
            _context.Formas.Remove(forma);
            await _context.SaveChangesAsync();
            return forma;
        }
    }
}

