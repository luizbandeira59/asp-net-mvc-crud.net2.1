using Modelo.CadastrosBLL;
using Modelo.ListasBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//BLL – Camada de Regra de negócios(Business Logic Layer)

namespace Modelo.CadastrosBLL
{
    public class StatusCompra
    {
        [Key]
        public long? StatusId { get; set; }
        [Display(Name = "Situação da Compra")]
        public string StatusNome { get; set; }

        public virtual ICollection<ListaMercado> Mercados { get; set; }
        public virtual ICollection<ListaDesejo> ListaDesejos { get; set; }
        public virtual ICollection<DespesaDir> DespesasDiretas { get; set; }
        public virtual ICollection<DespesaFixa> DespesasFixas { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<ProdutoStatus> ProdutosStatuss { get; set; }
    }
}
