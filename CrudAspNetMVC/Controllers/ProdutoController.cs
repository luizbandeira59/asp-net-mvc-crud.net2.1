using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAspNetMVC.Data;
using CrudAspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudAspNetMVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IESContext _context;
        public ProdutoController(IESContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.Include(c => c.Categoria).OrderBy(p => p.ProdutoNome).ToListAsync());
        }

        //GET PRODUTO/CREATE
        public IActionResult Create()
        {
            var categorias = _context.Categorias.OrderBy(c => c.CatNome).ToList();
            categorias.Insert(0, new Categoria() { CategoriaId = 0, CatNome = "Selecione a Categoria" });
            ViewBag.Categorias = categorias;
            return View();
        }

        //POST: PRODUTO/CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,ProdutoNome,ProdutoDescricao,CategoriaId")] Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(produto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(produto);
        }

        // GET: PRODUTO/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewBag.Categorias = new SelectList(_context.Categorias.OrderBy(c => c.CatNome), "CategoriaId", "CatNome", produto.CategoriaId);

            return View(produto);
        }


        //POST : PRODUTO/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ProdutoId,ProdutoNome,ProdutoDescricao,CategoriaId")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
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
            ViewBag.Categorias = new SelectList(_context.Categorias.OrderBy(c => c.CatNome), "CategoriaId", "CatNome", produto.CategoriaId);
            return View(produto);
        }

        // GET: PRODUTO/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);
            _context.Categorias.Where(i => produto.CategoriaId == i.CategoriaId).Load();
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: PRODUTO/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);
            _context.Categorias.Where(p => produto.CategoriaId == p.CategoriaId).Load();
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }


        // POST: PRODUTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);
            _context.Produtos.Remove(produto);
            TempData["Message"] = "Produto " + produto.ProdutoNome.ToUpper() + " foi removido com sucesso!";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(long? id)
        { 
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
