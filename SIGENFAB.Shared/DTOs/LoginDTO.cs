using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.DTOs
{
    public class LoginDTO
    {
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MinLength(6, ErrorMessage = "El campo {0} debe tener al menos {1} carácteres.")]
        public string Password { get; set; } = null!;

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MinLength(6, ErrorMessage = "El campo {0} debe tener al menos {1} carácteres.")]
        public string CPF { get; set; } = null!;
    }
}
