using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspNetMVC.Models
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

        public virtual ICollection<Mercado> Mercados { get; set; }
        public virtual ICollection<ListaDesejos> ListaDesejos { get; set; }       

    }
}
