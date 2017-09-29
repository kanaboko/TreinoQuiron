using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuironLojaVirtual.Domain.Entities;
using QuironLojaVirtual.Web.Models;

namespace QuironLojaVirtual.Web.ViewModel
{
    public class ProdutoViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public Paginacao Paginacao { get; set; }
        public string CategoriaAtual { get; set; }
    }
}