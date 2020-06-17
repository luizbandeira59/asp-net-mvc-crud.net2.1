using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudAspNetMVC.Data;
using CrudAspNetMVC.Data.DAL.Cadastros;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelo.Cadastros;
using Microsoft.AspNetCore.Authorization;

namespace CrudAspNetMVC.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    [Authorize]
    public class CategoriaController : Controller
    {
        private readonly IESContext _context;
        private readonly CategoriaDAL categoriaDAL;

        public CategoriaController(IESContext context)
        {
            _context = context;
            categoriaDAL = new CategoriaDAL(context);
        }

        //INDEX CATEGORIA/LISTA
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await categoriaDAL.PegarCategoriasPorNome().ToListAsync());
        }

        //GET: Categoria/Details/1
        [Authorize]
        public async Task<IActionResult> Details(long? id)
        {
            return await PegarViewCategoriaPorId(id);
        }

        //GET: Categoria/Edit/1
        /*
        public async Task<IActionResult> Edit(long? id)
        {
            return await PegarViewCategoriaPorId(id);
        }
        */
        //GET: Categoria/Delete/1
        /*
        public async Task<IActionResult> Delete(long? id)
        {
            return await PegarViewCategoriaPorId(id);
        }
        */

        //GET: Categoria/Create
        /*
        public IActionResult Create()
        {
            return View();
        }
        */

        //METODO PARA PEGAR VISAO DE CATEGORIA
        private async Task<IActionResult> PegarViewCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await categoriaDAL.PegarCategoriaPorId((long)id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        //POST: Categoria/Create
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatNome")] Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await categoriaDAL.CriarCategoria(categoria);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(categoria);
        }
        */

        //POST: Categoria/Edit/1

         /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("CategoriaId,CatNome")] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await categoriaDAL.CriarCategoria(categoria);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CategoriaExists(categoria.CategoriaId))
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
            return View(categoria);
        }
        */

        //POST: Categoria/Delete/1

         /*
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var categoria = await categoriaDAL.DeletarCategoriaPorId((long)id);
            TempData["Message"] = "Categoria " + categoria.CatNome.ToUpper() + " foi removida";
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CategoriaExists(long? id)
        {
            return await categoriaDAL.PegarCategoriaPorId((long)id) != null;
        }
        */

    }
}