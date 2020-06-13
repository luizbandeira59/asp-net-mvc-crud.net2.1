using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Modelo.Cadastros.Enums;

namespace Modelo.Cadastros
{
    public class ListaDesejos
    {
        
        [Key]
        public long? DesejoId { get; set; }

        [Display(Name = "Valor Do Produto")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double DesejoValor { get; set; }

        [Display(Name = "Previsão de Compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DesejoData { get; set; }

        [Display(Name = "Situação da Compra")]
        public StatusCompra Status { get; set; }

        [Display(Name = "Produto")]
        public Produto Produto { get; set; }
        public long? ProdutoId { get; set; }

        [Display(Name = "Método de Pagamento")]
        public FormaPagamento FormaPagamento  { get; set; }
        public long? FormaId { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
        public long? CategoriaId { get; set; }           

    }
}
