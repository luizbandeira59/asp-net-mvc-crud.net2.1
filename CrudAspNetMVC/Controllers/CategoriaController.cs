using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAspNetMVC.Data;
using CrudAspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudAspNetMVC.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IESContext _context;

        public CategoriaController(IESContext context)
        {
            this._context = context;
        }

        //INDEX CATEGORIA LISTA
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.OrderBy(c => c.CatNome).ToListAsync());
        }

        //Get CATEGORIA/CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatNome")] Categoria cat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cat);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(cat);
        }

        // GET: Departamento/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Categorias.SingleOrDefaultAsync(m => m.CategoriaId == id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        //POST: EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("CategoriaId,CatNome")] Categoria cat)
        {
            if (id != cat.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(cat.CategoriaId))
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
            return View(cat);
        }

        //MÉTODO EXIXT DE CATEGORIA
        private bool CategoriaExists(long? id)
        {
            return _context.Categorias.Any(e => e.CategoriaId == id);
        }

        //GET DETAILS
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Categorias.SingleOrDefaultAsync(m => m.CategoriaId == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // GET: Departamento/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Categorias.SingleOrDefaultAsync(m => m.CategoriaId == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var cat = await _context.Categorias.SingleOrDefaultAsync(m => m.CategoriaId == id);
            _context.Categorias.Remove(cat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}