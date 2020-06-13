using CrudAspNetMVC.Data;
using CrudAspNetMVC.Data.DAL.Cadastros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System.Linq;
using System.Threading.Tasks;


namespace CrudAspNetMVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IESContext _context;
        private readonly ProdutoDAL produtoDAL;
        private readonly CategoriaDAL categoriaDAL;

        public ProdutoController(IESContext context)
        {
            _context = context;
            categoriaDAL = new CategoriaDAL(context);
            produtoDAL = new ProdutoDAL(context);           
        }

        public async Task<IActionResult> Index()
        {
            return View(await produtoDAL.PegarProdutoPorNome().ToListAsync());
        }

        //GET Produto/Create
        public IActionResult Create()
        {
            var categorias = categoriaDAL.PegarCategoriasPorNome().ToList();
            categorias.Insert(0, new Categoria() { CategoriaId = 0, CatNome = "Selecione a Categoria" });
            ViewBag.Categorias = categorias;
            return View();
        }

        //POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoNome,ProdutoDescricao, CategoriaId")] Produto produto)     

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

        public async Task<IActionResult> Edit(long? id)
        {
            ViewResult viewProduto = (ViewResult)await PegarViewProdutoPorId(id);
            Produto produto = (Produto)viewProduto.Model;
            ViewBag.Categorias = new SelectList(categoriaDAL.PegarCategoriasPorNome(), "CategoriaId", "CatNome", produto.CategoriaId);
            return viewProduto;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ProdutoId, ProdutoNome, ProdutoDescricao, CategoriaId")] Produto produto)
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
                    if (!await DepartamentoExists(produto.ProdutoId))
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
            ViewBag.Categorias = new SelectList(categoriaDAL.PegarCategoriasPorNome(), "CategoriaId", "CatNome", produto.CategoriaId);
            return View(produto);
        }

        private async Task<bool> DepartamentoExists(long? id)
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
