using System;
using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Services;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class LeilaoController : Controller
    {
        IAdminService _adminService;
        IProdutoService _produtoService;


        public LeilaoController(IAdminService adminService, IProdutoService produtoService)
        {
            _adminService = adminService;
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            var leiloes = _adminService.BuscarLeiloesComCategoria();
            return View(leiloes);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = _adminService.BuscarCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _adminService.AdicionarLeilao(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _adminService.BuscarCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = _adminService.BuscarCategorias();
            ViewData["Operacao"] = "Edição";
            var leilao = _adminService.BuscarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            return View("Form", leilao);
        }

        [HttpPost]
        public IActionResult Edit(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _adminService.AlterarLeilao(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _adminService.BuscarCategorias();
            ViewData["Operacao"] = "Edição";
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var leilao = _adminService.BuscarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            _adminService.IniciaPregaoLeilaoComId(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var leilao = _adminService.BuscarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            _adminService.FinalizaPregaoLeilaoComId(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var leilao = _adminService.BuscarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            _adminService.ExcluiLeilaoComId(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _produtoService.BuscarLeiloesPorTermo(termo);
            return View("Index", leiloes);
        }
    }
}
