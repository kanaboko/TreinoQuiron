using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QuironLojaVirtual.Domain.Repository;

namespace QuironLojaVirtual.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private ProdutoRepository _produtoRepository;

        public ActionResult Menu(string categoria = null)
        {
            ViewBag.CategoriaSelecionada = categoria;

            _produtoRepository = new ProdutoRepository();

            IEnumerable<string> categorias =
                _produtoRepository
                .Produtos.Select(c => c.Categoria)
                .Distinct()
                .OrderBy(c => c);

            return PartialView(categorias);
        }
    }
}