using CrudAspNetMVC.Data;
using CrudAspNetMVC.Data.DAL.Listas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Listas;
using System.Threading.Tasks;


namespace CrudAspNetMVC.Areas.Listas.Controllers
{
    [Area("Listas")]
    [Authorize]
    public class DesejoController : Controller
    {
        private readonly IESContext _context;
        private readonly DesejoDAL desejoDAL;

        public DesejoController(IESContext context)
        {
            _context = context;
            desejoDAL = new DesejoDAL(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await desejoDAL.PegarDesejoPorNome().ToListAsync());
        }

        private async Task<IActionResult> PegarViewDesejoPorId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desejo = await desejoDAL.PegarDesejoPorId((long)id);
            if (desejo == null)
            {
                return NotFound();
            }

            return View(desejo);
        }

        public async Task<IActionResult> Details(long? id)
        {
            return await PegarViewDesejoPorId(id);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            return await PegarViewDesejoPorId(id);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            return await PegarViewDesejoPorId(id);
        }

        // GET: Desejo/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Desejo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesejoValor,DesejoData,Status,ProdutoId,FormaId,CategoriaId")] ListaDesejo desejo)
        { 
            try
            {
                if (ModelState.IsValid)
                {
                    await desejoDAL.RegistrarDesejo(desejo);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível cadastrar o produto.");
            }
            return View(desejo);
        }

        //POST: Desejo/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("DesejoId,DesejoValor,DesejoData,Status,ProdutoId,FormaId,CategoriaId")] ListaDesejo desejo)
        {
            if (id != desejo.DesejoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await desejoDAL.RegistrarDesejo(desejo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UsuarioExists(desejo.DesejoId))
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
            return View(desejo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var desejo = await desejoDAL.DeletarDesejoPorId((long)id);
            TempData["Message"] = "Produto " + desejo.Produto.ProdutoNome.ToUpper() + " foi removido com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UsuarioExists(long? id)
        {
            return await desejoDAL.PegarDesejoPorId((long)id) != null;
        }
    }
}