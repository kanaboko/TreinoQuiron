using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuironLojaVirtual.Domain.Entities;
using QuironLojaVirtual.Domain.Repository;
using System.Threading;

namespace QuironLojaVirtual.Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private ProdutoRepository _repository;

        // GET: Administrativo/Produto
        public ActionResult Index()
        {
            _repository = new ProdutoRepository();
            var produtos = _repository.Produtos;
            return View(produtos);
        }

        public ActionResult Alterar(int produtoId)
        {
            _repository = new ProdutoRepository();
            var produto = _repository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _repository = new ProdutoRepository();
                _repository.Alterar(produto);

                TempData["Mensagem"] = string.Format($"{produto.Nome} foi alterado com sucesso.");

                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Adicionar()
        {
            _repository = new ProdutoRepository();
            ViewBag.Categoria = new SelectList(_repository.Produtos.Select(p=>p.Categoria).Distinct());

            //ViewBag.Categorias = _repository.Produtos.Select(p => p.Categoria).Distinct().ToArray();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(Produto produto)
        {
            _repository = new ProdutoRepository();

            if (ModelState.IsValid)
            {
                _repository.Salvar(produto);

                TempData["Mensagem"] = string.Format($"{produto.Nome} adicionado com sucesso");

                return RedirectToAction("Index");
            }
            ViewBag.Categoria = new SelectList(_repository.Produtos.Select(p=>p.Categoria).Distinct(), produto.Categoria);

            return View(produto);

        }

        //[HttpPost]
        //public ActionResult Excluir(int produtoId)
        //{
        //    _repository = new ProdutoRepository();


        //    if (_repository.Remover(produtoId))
        //    {
        //        TempData["Mensagem"] = string.Format($"Produto excluido com sucesso");
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public JsonResult Excluir(int produtoId)
        {
            _repository = new ProdutoRepository();

            Thread.Sleep(5000);

            string mensagem = string.Empty;

            if (_repository.Remover(produtoId))
            {
                mensagem = string.Format($"Produto excluido com sucesso");
            }

            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }
    }
}