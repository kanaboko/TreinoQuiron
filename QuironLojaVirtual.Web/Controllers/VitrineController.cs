using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuironLojaVirtual.Domain.Repository;

namespace QuironLojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutoRepository _produtoRepository;
        
        public int ProdutosPorPagina = 3;

        // GET: Produto
        public ActionResult Index(int pagina = 1)
        {
            _produtoRepository = new ProdutoRepository();
            var produtos = _produtoRepository.Produtos
                .OrderBy(p => p.Descricao)
                .Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina);

            return View(produtos);
        }
    }
}