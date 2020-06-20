using Microsoft.EntityFrameworkCore;
using Modelo.CadastrosBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Data Acess Layer - Camada de acesso a dados - DAL - responsável por realizar o acesso e a persistência aos dados fazendo a comunicação entre a BLL e UI;.
//BLL – Camada de Regra de negócios(Business Logic Layer); UI – Camada de Apresentação(User Interface)

namespace CrudAspNetMVC.Data.CamadaAcessoDados.Cadastros
{
    public class StatusServicos
    {
        //INSTANCIANDO A CONTEXT PARA INJEÇÃO DE DEPENDÊNCIA
        private ControleContext _context;

        //MÉTODO CONSTRUTOR
        public StatusServicos(ControleContext context)
        {
            _context = context;
        }

        //IQueryable<> é específico para o LINQ.Um IQueryable<> também é 
        //derivado de um IEnumerable<T> e admite lazy loading permitindo uma melhor otimização 
        //de uma consulta.Ou seja, apenas os elementos realmente necessários para uma determinada 
        //operação são retornados na consulta para futura análise.
        public IQueryable<StatusCompra> PegarStatusPorNome()
        {
            return _context.Status.OrderBy(c => c.StatusNome);
        }

        //MÉTODO PARA BUSCAR UM STATUS DE COMPRA DA LISTA DE STATUS POR ID(KEY)
        //Você pode usar o método Include para especificar os dados relacionados a serem incluídos nos resultados da consulta.
        public async Task<StatusCompra> PegarStatusPorId(long id)
        {
            return await _context.Status.Include(p => p.Produtos)
                .Include(l => l.ListaDesejos).Include(m => m.Mercados)
                .SingleOrDefaultAsync(m => m.StatusId == id);
        }

        public async Task<StatusCompra> CriarStatus(StatusCompra status)
        {
            if (status.StatusId == null)
            {
                _context.Status.Add(status);
            }
            else
            {
                _context.Update(status);
            }
            await _context.SaveChangesAsync();
            return status;
        }

        public async Task<StatusCompra> DeletarCategoriaPorId(long id)
        {
            StatusCompra status = await PegarStatusPorId(id);
            _context.Status.Remove(status);
            await _context.SaveChangesAsync();
            return status;
        }
    }

}
