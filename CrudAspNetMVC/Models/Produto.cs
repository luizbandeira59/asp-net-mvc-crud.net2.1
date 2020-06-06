using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspNetMVC.Models
{
    public class Produto
    {
        [Key]
        public long? ProdutoId { get; set; }

        [Display(Name = "Nome do Produto")]
        public string ProdutoNome { get; set; }

        [Display(Name = "Descrição do Produto")]
        public string ProdutoDescricao { get; set; }
    }
}
