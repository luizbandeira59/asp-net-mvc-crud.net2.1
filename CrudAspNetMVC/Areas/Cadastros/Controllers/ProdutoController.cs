using CrudAspNetMVC.Data;
using CrudAspNetMVC.Data.CamadaAcessoDados.Cadastros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.CadastrosBLL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CrudAspNetMVC.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly ControleContext _context;
        private readonly ProdutoServicos produtoDAL;
        private readonly CategoriaServicos categoriaDAL;
        private readonly FormaServicos formaDAL;
        private readonly StatusServicos statusDAL;

        public ProdutoController(ControleContext context)
        {
            _context = context;
            categoriaDAL = new CategoriaServicos(context);
            produtoDAL = new ProdutoServicos(context);           
            formaDAL = new FormaServicos(context);        
            statusDAL = new StatusServicos(context);        
        }

        //RETORNA PRODUTO POR NOME CHAMANDO O MÉTODO DA CAMADA DE SERVIÇOS DE CADASTROS
        public async Task<IActionResult> Index()
        {
            return View(await produtoDAL.PegarProdutoPorNome().ToListAsync());
        }


        //GET Produto/Create   
        [HttpGet]
        public IActionResult Create()
        {

            //CHAMA O MÉTODO DA CAMADA DE SERVIÇOS ATRIBUINDO-O EM UM VAR,
            //ORDENANDO POR UMA COLEÇÃO DE LISTAS GENÉRICAS, INSERE POR PARAMÊTRO OS ATRIBUTOS DA CLASSE DENTRO DA VAR,
            //INSTANCIANDO UMA VIEWBAG QUE VAI RECEBER OS DADOS ATRIBUIDOS PELA VAR

            var categorias = categoriaDAL.PegarCategoriasPorNome().ToList();
            categorias.Insert(0, new Categoria() { CategoriaId = 0, CatNome = "Selecione a Categoria" });
            ViewBag.Categorias = categorias;

            var formas = formaDAL.PegarFormaPorNome().ToList();
            formas.Insert(0, new FormaPagamento() { FormaId = 0, FormaNome = "Selecione a forma de Pagamento" });
            ViewBag.Formas = formas;

            var status = statusDAL.PegarStatusPorNome().ToList();
            status.Insert(0, new StatusCompra() { StatusId = 0, StatusNome = "Selecione a situação da compra" });
            ViewBag.StatusCompras = status;

            return View();

        }

        //POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoNome,ProdutoDescricao, CategoriaId,FormaId,StatusId")] Produto produto)     

        {
            try
            {
                if (ModelState.IsValid)
                {
                    await produtoDAL.CriarProduto(produto);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(produto);
        }

        //GET: Produto/Edit
        public async Task<IActionResult> Edit(long? id)
        {

            //CHAMA A VIEW DE PRDUTOS, CRIANDO VIEWBAGS COM OS ARGUMENTOS PARA UM SELECT/DROPDOWN NA VIEW

            ViewResult viewProduto = (ViewResult)await PegarViewProdutoPorId(id);
            Produto produto = (Produto)viewProduto.Model;

            ViewBag.Categorias = new SelectList(categoriaDAL.PegarCategoriasPorNome()
                , "CategoriaId", "CatNome", produto.CategoriaId);

            ViewBag.Formas = new SelectList(formaDAL.PegarFormaPorNome()
                , "FormaId", "FormaNome", produto.FormaId);

            ViewBag.Status = new SelectList(statusDAL.PegarStatusPorNome()
              , "StatusId", "StatusNome", produto.StatusId);

            return viewProduto;
        }


        //POST: Produto/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ProdutoId, ProdutoNome, ProdutoDescricao, CategoriaId, FormaId, StatusId")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await produtoDAL.CriarProduto(produto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProdutoExists(produto.ProdutoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            //INSTANCIANDO VIEWBAGS PARA CARREGAR O SELECT/DROPDOWN NA VIEW
            ViewBag.Categorias = new SelectList(categoriaDAL.PegarCategoriasPorNome(), "CategoriaId", "CatNome", produto.CategoriaId);
            ViewBag.Formas = new SelectList(formaDAL.PegarFormaPorNome(), "FormaId", "FormaNome", produto.FormaId);
            ViewBag.StatusCompras = new SelectList(statusDAL.PegarStatusPorNome(), "StatusId", "StatusNome", produto.StatusId);
            return View(produto);
        }

        //MÉTODO PARA VERIFICAR SE O PRODUTO JA EXISTE POR ID[KEY]/ CHAAMANDO O MÉTODO DA CAMADA DE SERVICOS
        private async Task<bool> ProdutoExists(long? id)
        {
            return await produtoDAL.PegarProdutoPorId((long)id) != null;
        }

       
        public async Task<IActionResult> Details(long? id)
        {
            return await PegarViewProdutoPorId(id);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            return await PegarViewProdutoPorId(id);
        }

        // POST: Instituicao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var produto = await produtoDAL.DeletarProdutoPorId((long)id);
            TempData["Message"] = "Produto " + produto.ProdutoNome.ToUpper() + " foi removido com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        //MÉTODO PAGA PEGAR A VIEW DE PRODUTO, PARA RENDERIZAR OS ITENS DENTRO DAS VIEWS DELETE E DETAILS
        private async Task<IActionResult> PegarViewProdutoPorId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await produtoDAL.PegarProdutoPorId((long)id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }
    }
}
