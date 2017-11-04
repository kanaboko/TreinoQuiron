using QuironLojaVirtual.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuironLojaVirtual.Domain.Repository
{
    public class AdministradorRepository
    {
        private readonly EFDbContext _context = new EFDbContext();

        public Administrador ObterAdministrador(Administrador administrador)
        {
            return _context.Administradores.FirstOrDefault(a => a.Login == administrador.Login);
        }
    }
}
