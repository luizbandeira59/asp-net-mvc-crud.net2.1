using Modelo.ListasBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Modelo.CadastrosBLL;

//BLL – Camada de Regra de negócios(Business Logic Layer)

namespace Modelo.CadastrosBLL
{
    public class Categoria
    {
        [Key]
        public long? CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public string CatNome { get; set; }
    
        public virtual ICollection<ListaMercado> Mercados { get; set; }
        public virtual ICollection<ListaDesejo> ListaDesejos { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<DespesaDir> DespesaDiretas { get; set; }
        public virtual ICollection<DespesaFixa> DespesasFixas { get; set; }

    }
}
