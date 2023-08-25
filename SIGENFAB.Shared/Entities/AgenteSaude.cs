using SIGENFAB.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class AgenteSaude : IFuncionario
    {
        public int Id { get; set; }
        public Usuario? Usuario { get; set; }

        [Display(Name = "Matrícula")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Matricula { get; set; } = null!;

        [Display(Name = "Microárea")]
        //[Range(1, int.MaxValue, ErrorMessage = "Selecione a Microárea")]
        public int? MicroId { get; set; }

        public Micro? Micro { get; set; }
    }
}
