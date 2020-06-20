using Modelo.ListasBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//BLL – Camada de Regra de negócios(Business Logic Layer)

namespace Modelo.CadastrosBLL
{
    public class FormaPagamento
    {
        
        [Key]
        public long? FormaId { get; set; }
        [Display(Name = "Método de Pagamento")]
        public string FormaNome { get; set; }

        public virtual ICollection<ListaMercado> Mercados { get; set; }
        public virtual ICollection<ListaDesejo> ListaDesejos { get; set; }
        public virtual ICollection<DespesaDir> DespesasDiretas { get; set; }
        public virtual ICollection<DespesaFixa> DespesasFixas { get; set; }
        public virtual ICollection<PagamentoProduto> PagamentoProdutos { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
