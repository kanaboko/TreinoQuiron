using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuironLojaVirtual.Domain.Entities
{
    public class Produto
    {
        [Display(Name = "Produto ID:")]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "Ops! Você esqueceu o nome")]
        [Display(Name = "Nome do produto:")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Ops! Você esqueceu a descrição")]
        [Display(Name = "Descrição do produto:")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Ops! Você esqueceu o preço")]
        [Display(Name = "Preço do produto:")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor inválido")]
        [DataType(DataType.Currency,ErrorMessage = "Valor inválido")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Ops! Você esqueceu a categoria")]
        [Display(Name = "Categoria:")]
        public string Categoria { get; set; }
        public byte[] Imagem { get; set; }
        public string ImageMimeType { get; set; }
    }
}
