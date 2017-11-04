using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using QuironLojaVirtual.Domain.Entities;

namespace QuironLojaVirtual.Domain.Repository
{
    public class ProdutoRepository
    {
    
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; } 
        }

        public void Salvar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Alterar(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool Remover(int produtoId)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                //_context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
