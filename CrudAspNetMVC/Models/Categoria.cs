using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspNetMVC.Models
{
    public class Categoria
    {
        [Key]
        public long? CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public string CatNome { get; set; }

        /*
        [Display(Name = "Produto")]
        public Produto Produto { get; set; }
        public long? ProdutoId { get; set; }
        */

        /*
         *public ListaDesejos ListaDesejos { get; set; }
         public long? DesejoId { get; set; } 
         */

        /*
        public Mercado Mercado { get; set; }
        public long? MercadoId { get; set; }
        */

        public virtual ICollection<Mercado> Mercados { get; set; }
        public virtual ICollection<ListaDesejos> ListaDesejos { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
