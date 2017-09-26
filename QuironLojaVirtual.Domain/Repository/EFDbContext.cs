using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuironLojaVirtual.Domain.Entities;

namespace QuironLojaVirtual.Domain.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
    }
}
