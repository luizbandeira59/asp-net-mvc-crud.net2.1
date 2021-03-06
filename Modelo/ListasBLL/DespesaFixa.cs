﻿using Modelo.CadastrosBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//BLL – Camada de Regra de negócios(Business Logic Layer)

namespace Modelo.ListasBLL
{
    public class DespesaFixa
    {
        [Key]
        public long? DespesaFixId { get; set; }

        [Display(Name = "Valor Da Despesa")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double DespFixValor { get; set; }

        [Display(Name = "Data da Despesa")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DespFixData { get; set; }

        [Display(Name = "Situação Compra")]
        public StatusCompra Status { get; set; }
        public long? StatusId { get; set; }

        [Display(Name = "Método de Pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
        public long? FormaId { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
        public long? CategoriaId { get; set; }

        [Display(Name = "Produto")]
        public Produto Produto { get; set; }
        public long? ProdutoId { get; set; }
    }
}


