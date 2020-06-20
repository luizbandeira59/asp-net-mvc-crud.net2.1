using System.Linq;
using System.Threading.Tasks;
using Modelo.CadastrosBLL;
using Microsoft.EntityFrameworkCore;


//Data Acess Layer - Camada de acesso a dados - DAL - responsável por realizar o acesso e a persistência aos dados fazendo a comunicação entre a BLL e UI;.
//BLL – Camada de Regra de negócios(Business Logic Layer); UI – Camada de Apresentação(User Interface)

namespace CrudAspNetMVC.Data.CamadaAcessoDados.Cadastros
{
    public class CategoriaServicos
    {
        //INSTANCIANDO A CONTEXT PARA INJEÇÃO DE DEPENDÊNCIA 
        private ControleContext _context;

        //MÉTODO CONSTRUTOR
        public CategoriaServicos(ControleContext context)
        {
            _context = context;
        }

        //IQueryable<> é específico para o LINQ.Um IQueryable<> também é 
        //derivado de um IEnumerable<T> e admite lazy loading permitindo uma melhor otimização 
        //de uma consulta.Ou seja, apenas os elementos realmente necessários para uma determinada 
        //operação são retornados na consulta para futura análise.
        public IQueryable<Categoria> PegarCategoriasPorNome()
        {
            return _context.Categorias.OrderBy(c => c.CatNome);
        }

        //MÉTODO PARA BUSCAR UMA CATEGORIA POR ID(KEY)
        //Você pode usar o método Include para especificar os dados relacionados a serem incluídos nos resultados da consulta.
        public async Task<Categoria> PegarCategoriaPorId(long id)
        {
            return await _context.Categorias.Include(p => p.Produtos)
                .Include(l => l.ListaDesejos).Include(m => m.Mercados)
                .SingleOrDefaultAsync(m => m.CategoriaId == id);
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
