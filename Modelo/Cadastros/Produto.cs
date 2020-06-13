using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Cadastros
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

        public virtual ICollection<Mercado> Mercados { get; set; }
        public virtual ICollection<ListaDesejos> ListaDesejos { get; set; }
        public virtual ICollection<DespesaDir> DespesasDiretas { get; set; }

    }
}
