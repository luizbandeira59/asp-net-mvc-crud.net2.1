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

        //INDEX CATEGORIA/LISTA
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.OrderBy(c => c.CatNome).ToListAsync());
        }

        //GET CATEGORIAS/DETAILS/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var categoria = await _context.Categorias.Include(p => p.Produtos).SingleOrDefaultAsync(c => c.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }
       
    }
}