using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAspNetMVC.Controllers
{
    public class ProdutoController : Controller
    {
        private static IList<Produto> produtos = new List<Produto>()
        {
            new Produto() {
                ProdutoId = 1,
                ProdutoNome = "CELULAR A50",
                ProdutoDescricao = "CELULAR SAMSUNG A50 128GB"
            },
            new Produto() {
                ProdutoId = 2,
                ProdutoNome = "MONITOR 22 DELL",
                ProdutoDescricao = "MONITOR DELL P2219H FULLHD"
            },
            new Produto() {
                ProdutoId = 3,
                ProdutoNome = "TV LED 4K SAMSUNG 50",
                ProdutoDescricao = "TV LED 4K SANSUMG RU7100 50 POLEDADAS"
            },
            new Produto() {
                ProdutoId = 4,
                ProdutoNome = "BOLSA GRANDE FEMININA DE COURO",
                ProdutoDescricao = "BOLSA GRANDE FEMININA DE COURO MACIO COM 2 ALÇAS"
            },
            new Produto() {
                ProdutoId = 5,
                ProdutoNome = "XIAOMI SMARTWATCH AMAZIFIT BIP",
                ProdutoDescricao = "AMAZIFIT BIP XIAOMI A1608, PRETO"
            },

                new Produto() {
                ProdutoId = 6,
                ProdutoNome = "GAMEPAD 5X1 PARA CELULAR",
                ProdutoDescricao = " SUPORTE PARA CELULAR GAMEPAD 5 EM 1"
            },
            new Produto() {
                ProdutoId = 7,
                ProdutoNome = "XIAOMI MIBAND 4",
                ProdutoDescricao = "PULSEIRA XIAOMI MIBAND 4 PRETO"
            },
            new Produto() {
                ProdutoId = 8,
                ProdutoNome = "TAPETE DE SISAL 2X3M",
                ProdutoDescricao = "TAPETE SISAL 2X3M"
            },
            new Produto() {
                ProdutoId = 9,
                ProdutoNome = "PANELA PRESSÃO 10L",
                ProdutoDescricao = "PANELA PRESSÃO 10L EIRILAR TRAVA EXTERNA"
            },
            new Produto() {
                ProdutoId = 10,
                ProdutoNome = "SUPORTE DE TABLET",
                ProdutoDescricao = "SUPORTE DE MESA PARA TABLET"
            },

        };

        /*INDEX*/
        public IActionResult Index()
        {
            return View(produtos.OrderBy(i => i.ProdutoNome));
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        /*CREATE POST*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto pd)
        {
            produtos.Add(pd);
            pd.ProdutoId = produtos.Select(i => i.ProdutoId).Max() + 1;
            return RedirectToAction("Index");
        }

        /*EDITAR */
        public ActionResult Edit(long id)
        {
            return View(produtos.Where(i => i.ProdutoId == id).First());
        }

        /*EDIT POST*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto pd)
        {
            produtos.Remove(produtos.Where(i => i.ProdutoId == pd.ProdutoId).First());
            produtos.Add(pd);
            return RedirectToAction("Index");
        }
        
        /*DETALHES*/
        public ActionResult Details(long id)
        {
            return View(produtos.Where(i => i.ProdutoId == id).First());
        }

        /*DELETAR*/
        public ActionResult Delete(long id)
        {
            return View(produtos.Where(i => i.ProdutoId == id).First());
        }

        /*DELETAR POST*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Produto pd)
        {
            produtos.Remove(produtos.Where(i => i.ProdutoId == pd.ProdutoId).First());
            return RedirectToAction("Index");
        }
    }
}
