using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Modelo.CadastrosBLL;
using Modelo.ListasBLL;

//BLL – Camada de Regra de negócios(Business Logic Layer)

namespace Modelo.ListasBLL
{
    public class ListaMercado
    {
        [Key]
        public long? MercadoId { get; set; }
        public double MercadoValor { get; set; }
        public DateTime MercadoData { get; set; }

        [Display(Name = "Situação da Compra")]
        public StatusCompra Status { get; set; }
        public long? StatusId { get; set; }

        [Display(Name = "Produto")]
        public Produto Produto { get; set; }
        public long? ProdutoId { get; set; }

        [Display(Name = "Método de Pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
        public long? FormaId { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
        public long? CategoriaId { get; set; }

    }
}
