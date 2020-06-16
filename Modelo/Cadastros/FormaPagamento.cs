using Modelo.Listas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Cadastros
{
    public class FormaPagamento
    {
        
        [Key]
        public long? FormaId { get; set; }
        [Display(Name = "Método de Pagamento")]
        public string FormaNome { get; set; }

        /*
        public ListaDesejos ListaDesejos { get; set; }
        public long? DesejoId { get; set; }
        */

        /*
        public Mercado Mercado { get; set; }
        public long? MercadoId { get; set; }
        */

        public virtual ICollection<ListaMercado> Mercados { get; set; }
        public virtual ICollection<ListaDesejo> ListaDesejos { get; set; }
        public virtual ICollection<DespesaDir> DespesasDiretas { get; set; }
        public virtual ICollection<DespesaFixa> DespesasFixas { get; set; }
        public virtual ICollection<PagamentoProduto> PagamentoProdutos { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
