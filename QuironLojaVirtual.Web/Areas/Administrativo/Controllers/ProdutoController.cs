using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuironLojaVirtual.Domain.Entities;
using QuironLojaVirtual.Domain.Repository;

namespace QuironLojaVirtual.Web.Areas.Administrativo.Controllers
{
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
    }
}