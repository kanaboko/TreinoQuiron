using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuironLojaVirtual.Domain.Repository;
using QuironLojaVirtual.Web.Models;
using QuironLojaVirtual.Web.ViewModel;

namespace QuironLojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutoRepository _produtoRepository;
        
        public int ProdutosPorPagina = 3;

        // GET: Produto
        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            _produtoRepository = new ProdutoRepository();
            ProdutoViewModel model = new ProdutoViewModel
            {

                Produtos = _produtoRepository.Produtos
                    .Where(p=>categoria==null||p.Categoria == categoria)
                    .OrderBy(p => p.Descricao)
                    .Skip((pagina - 1) * ProdutosPorPagina)
                    .Take(ProdutosPorPagina),
                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _produtoRepository.Produtos.Where(p=>categoria==null||p.Categoria==categoria).Count()
                },
                CategoriaAtual = categoria
            };
            return View(model);
        }
    }
}