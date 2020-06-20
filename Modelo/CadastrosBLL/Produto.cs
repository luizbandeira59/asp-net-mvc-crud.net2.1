using Modelo.ListasBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//BLL – Camada de Regra de negócios(Business Logic Layer)

namespace Modelo.CadastrosBLL
{
    public class Produto
    {
        [Key]
        public long? ProdutoId { get; set; }

        [Display(Name = "Produto")]
        public string ProdutoNome { get; set; }

        [Display(Name = "Descrição do Produto")]
        public string ProdutoDescricao { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
        public long? CategoriaId { get; set; }

        [Display(Name = "Forma de Pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
        public long? FormaId { get; set; }

        [Display(Name = "Status Compra")]
        public StatusCompra StatusCompra { get; set; }
        public long? StatusId { get; set; }

        public virtual ICollection<ListaMercado> Mercados { get; set; }
        public virtual ICollection<ListaDesejo> Desejos { get; set; }
        public virtual ICollection<DespesaDir> DespesasDiretas { get; set; }
        public virtual ICollection<DespesaFixa> DespesasFixas { get; set; }
        public virtual ICollection<PagamentoProduto> PagamentoProdutos { get; set; }
        public virtual ICollection<ProdutoStatus> ProdutosStatuss { get; set; }
    }
}
