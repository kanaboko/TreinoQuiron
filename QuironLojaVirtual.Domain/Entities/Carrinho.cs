using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuironLojaVirtual.Domain.Entities
{

    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();

        public void AdcionarItem(Produto produto, int quantidade)
        {
            
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(i => i.Produto.ProdutoId == produto.ProdutoId);
            if (item == null)
            {
                _itemCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }

        public void RemoverItem(Produto produto)
        {
            _itemCarrinho.RemoveAll(p=>p.Produto.ProdutoId==produto.ProdutoId);
        }

        public decimal ObterValorTotal()
        {

            return _itemCarrinho.Sum(p => p.Produto.Preco * p.Quantidade);

        }

        public void LimparCarrinho()
        {
            _itemCarrinho.Clear();
        }

        public IEnumerable<ItemCarrinho> ItensCarrinho => _itemCarrinho;

    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
