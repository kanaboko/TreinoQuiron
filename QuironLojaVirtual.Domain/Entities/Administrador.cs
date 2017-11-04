using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuironLojaVirtual.Domain.Entities
{
    public class Administrador { 
    
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Insira o Login")]
        [Display(Name ="Login: ")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insira a Senha")]
        [Display(Name = "Senha: ")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UltimoAcesso { get; set; }

    }
}
