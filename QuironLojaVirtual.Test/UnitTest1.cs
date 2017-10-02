using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuironLojaVirtual.Web.Helpers;
using QuironLojaVirtual.Web.Models;
using QuironLojaVirtual.Web.ViewModel;
using QuironLojaVirtual.Domain.Entities;

namespace QuironLojaVirtual.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestarPaginacao()
        {
            //Arrange
            HtmlHelper html = null;
            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
                
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            //Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                          + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                          + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>",resultado.ToString());
        }

        [TestMethod]
        public void TesteDoCarrinho()
        {
            Produto produto1 = new Produto()
            {
                Categoria = "Basquete",
                Descricao = "Bola de basquete de couro",
                Nome = "Bola Penalty",
                Preco = 49,
                ProdutoId = 1
            };
            Produto produto2 = new Produto()
            {
                Categoria = "Futebol",
                Descricao = "Bola de futebol de couro",
                Nome = "Bola Rainha",
                Preco = 79,
                ProdutoId = 2
            };
            //Arrqnge
            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(produto1, 2);
            carrinho.AdcionarItem(produto2,3);
            //Act
            ItemCarrinho[] item = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(item.Length, 2);

            Assert.AreEqual(item[0].Produto, produto1);

            Assert.AreEqual(item[1].Produto, produto2);
        }

        [TestMethod]
        public void TesteDoAdicionarNoCarrinho()
        {
            Produto produto1 = new Produto()
            {
                Categoria = "Basquete",
                Descricao = "Bola de basquete de couro",
                Nome = "Bola Penalty",
                Preco = 49,
                ProdutoId = 1
            };
            Produto produto2 = new Produto()
            {
                Categoria = "Futebol",
                Descricao = "Bola de futebol de couro",
                Nome = "Bola Rainha",
                Preco = 79,
                ProdutoId = 2
            };
            //Arrqnge
            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(produto1, 2);
            carrinho.AdcionarItem(produto2, 3);
            carrinho.AdcionarItem(produto1, 1);
            //Act
            ItemCarrinho[] item = carrinho.ItensCarrinho.OrderBy(c => c.Produto.ProdutoId).ToArray();
            //Assert
            Assert.AreEqual(item.Length,2);
            Assert.AreEqual(item[0].Quantidade, 3);
        }

        [TestMethod]
        public void TesteDoRemoverItemCarrinho()
        {
            Produto produto1 = new Produto()
            {
                Categoria = "Basquete",
                Descricao = "Bola de basquete de couro",
                Nome = "Bola Penalty",
                Preco = 49,
                ProdutoId = 1
            };
            Produto produto2 = new Produto()
            {
                Categoria = "Futebol",
                Descricao = "Bola de futebol de couro",
                Nome = "Bola Rainha",
                Preco = 79,
                ProdutoId = 2
            };
            //Arrqnge
            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(produto1, 2);
            carrinho.AdcionarItem(produto2, 3);
            carrinho.AdcionarItem(produto1, 1);
            carrinho.RemoverItem(produto1);
            //Act
            ItemCarrinho[] item = carrinho.ItensCarrinho.OrderBy(c => c.Produto.ProdutoId).ToArray();

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Where(p=>p.Produto == produto1).Count(),0);
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 1);
        }

        [TestMethod]
        public void TesteValorTotalCarrinho()
        {
            Produto produto1 = new Produto()
            {
                Categoria = "Basquete",
                Descricao = "Bola de basquete de couro",
                Nome = "Bola Penalty",
                Preco = 49,
                ProdutoId = 1
            };
            Produto produto2 = new Produto()
            {
                Categoria = "Futebol",
                Descricao = "Bola de futebol de couro",
                Nome = "Bola Rainha",
                Preco = 79,
                ProdutoId = 2
            };
            //Arrqnge
            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(produto1, 2);
            carrinho.AdcionarItem(produto2, 3);
            carrinho.AdcionarItem(produto1, 1);
            carrinho.RemoverItem(produto1);
            //Act
            ItemCarrinho[] item = carrinho.ItensCarrinho.OrderBy(c => c.Produto.ProdutoId).ToArray();

            //Assert
            Assert.AreEqual(carrinho.ObterValorTotal(),79*3);
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 1);

        }
    }
}
