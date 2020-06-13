using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAspNetMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros.Enums;

namespace CrudAspNetMVC.Controllers
{
    public class ListaDesejoController : Controller
    {
        private readonly IESContext _context;
        public ListaDesejoController(IESContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Desejos.OrderBy(c => c.Categoria).ToListAsync());
        }
    }
}