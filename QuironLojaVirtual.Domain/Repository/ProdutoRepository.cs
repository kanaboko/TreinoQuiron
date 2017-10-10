using System;
using System.Collections.Generic;
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

        
    }
}
