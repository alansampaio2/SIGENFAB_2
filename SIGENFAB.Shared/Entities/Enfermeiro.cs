using SIGENFAB.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Enfermeiro : IFuncionario
    {
        public int Id { get; set; }
        public Usuario? Usuario { get; set; }

        [Display(Name = "Matrícula")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Matricula { get; set; } = null!;

        [Display(Name = "COREN-UF")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string COREN_UF { get; set; } = null!;

        [Display(Name = "Área")]
        public int? AreaId { get; set; }

        public Area? Area { get; set; }
    }
}
