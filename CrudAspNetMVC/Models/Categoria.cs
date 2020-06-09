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

        [Display(Name = "Nome")]
        public string CatNome { get; set; }
    }
}
