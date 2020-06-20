using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo.ListasBLL;
using Microsoft.EntityFrameworkCore;

//Data Acess Layer - Camada de acesso a dados - DAL - responsável por realizar o acesso e a persistência aos dados fazendo a comunicação entre a BLL e UI;.
//BLL – Camada de Regra de negócios(Business Logic Layer); UI – Camada de Apresentação(User Interface)

namespace CrudAspNetMVC.Data.CamadaAcessoDados.Listas
{
    public class DesejoServicos
    { 
        //INSTANCIANDO A CONTEXT PARA INJEÇÃO DE DEPENDÊNCIA
        private ControleContext _context;

        //MÉTODO CONSTRUTOR
        public DesejoServicos(ControleContext context)
        {
            _context = context;
        }

        //IQueryable<> é específico para o LINQ.Um IQueryable<> também é 
        //derivado de um IEnumerable<T> e admite lazy loading permitindo uma melhor otimização 
        //de uma consulta.Ou seja, apenas os elementos realmente necessários para uma determinada 
        //operação são retornados na consulta para futura análise.
        
        public IQueryable<ListaDesejo> PegarDesejoPorNome()
        {
            return _context.Desejos.OrderBy(b => b.Produto.ProdutoNome);
        }


        //MÉTODO PARA BUSCAR UM PRODUTO DA LISTA DE DESEJOS POR ID(KEY)
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
