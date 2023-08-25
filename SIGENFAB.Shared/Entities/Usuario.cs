using Microsoft.AspNetCore.Identity;
using SIGENFAB.Shared.Enums;
using SIGENFAB.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Usuario : IdentityUser, IPessoa
    {
        public UsuarioTipo UsuarioTipo { get; set; }

        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Sobrenome")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Sobrenome { get; set; } = null!;

        [Display(Name = "CPF")]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CPF { get; set; } = null!;

        [Display(Name = "CNS")]
        [MaxLength(25, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CNS { get; set; } = null!;

        [Display(Name = "Data de Nascimento")]
        [MaxLength(25, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime Nascimento { get; set; }

        public Sexo Sexo { get; set; }

        public bool IsActive { get; set; }

        public string NomeCompleto => $"{Nome} {Sobrenome}";
    }
}
