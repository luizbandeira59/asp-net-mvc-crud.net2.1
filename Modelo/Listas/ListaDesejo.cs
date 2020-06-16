using Modelo.Cadastros;
using Modelo.Cadastros.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelo.Listas
{
    public class ListaDesejo
    {
        [Key]
        public long? DesejoId { get; set; }

        [Display(Name = "Valor Do Produto")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required]
        public double DesejoValor { get; set; }

        [Display(Name = "Previsão de Compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Required]
        public DateTime DesejoData { get; set; }


        [Display(Name = "Situação da Compra")]//usar linq
        public StatusCompra Status { get; set; }

        [Display(Name = "Produto")]
        [Required]
        public Produto Produto { get; set; }
        public long? ProdutoId { get; set; }

        [Display(Name = "Método de Pagamento")]//usar linq ou select list
        public FormaPagamento FormaPagamento { get; set; }
        public long? FormaId { get; set; }

        [Display(Name = "Categoria")]//usar o select list do dropdown
        public Categoria Categoria { get; set; }
        public long? CategoriaId { get; set; }
    }
}
