using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Cadastros
{
    public class Categoria
    {
        [Key]
        public long? CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public string CatNome { get; set; }
    
        public virtual ICollection<Mercado> Mercados { get; set; }
        public virtual ICollection<ListaDesejos> ListaDesejos { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<DespesaDir> DespesasDiretas { get; set; }

    }
}
