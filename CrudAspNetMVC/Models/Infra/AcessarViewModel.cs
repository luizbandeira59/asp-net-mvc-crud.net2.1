using System.ComponentModel.DataAnnotations;

//UI – Camada de Apresentação(User Interface)

namespace CrudAspNetMVC.Models.Infra
{
    public class AcessarViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        //P@ssw0rd -- senha precisa de uma letra maiúscula, um número, e um caractere especial.

        [Display(Name = "Lembrar de mim?")]
        public bool LembrarDeMim { get; set; }
    }
}
