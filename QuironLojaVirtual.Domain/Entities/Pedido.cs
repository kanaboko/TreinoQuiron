using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuironLojaVirtual.Domain.Entities
{
    public class Pedido
    {
        [Required(ErrorMessage = "Ops!! Você esqueceu de preencher seu nome")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }
        [Display(Name = "Cep:")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Ops!! Você esqueceu de preencher seu endereço")]
        [Display(Name = "Endereço:")]
        public string Endereco { get; set; }
        [Display(Name = "Complemento:")]
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Ops!! Você esqueceu de preencher sua cidade ")]
        [Display(Name = "Cidade:")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Ops!! Você esqueceu de preencher seu bairro")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Ops!! Você esqueceu de preencher seu estado")]
        [Display(Name = "Estado:")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Ops!! Você esqueceu de preencher seu e-mail")]
        [Display(Name = "E-Mail:")]
        [EmailAddress(ErrorMessage = "Informe um endereço válido")]
        public string Email { get; set; }
        [Display(Name = "Embrulha para presente:")]
        public bool EmbrulhaPresente { get; set; }

    }
}
