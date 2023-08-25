using SIGENFAB.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Residencia
    {
        public int Id { get; set; }

        [Display(Name = "Paciente")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione o Paciente")]
        public int PacienteId { get; set; }

        [Display(Name = "Domicílio")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione o Domicílio")]
        public int DomicilioId { get; set; }
        public bool EhResponsavel { get; private set; }
        public Parentesco ParentescoComResponsavel { get; private set; }
        public bool PossuiRenda { get; private set; }
        public Paciente? Paciente { get; set; }
        public Domicilio? Domicilio { get; set; }
    }
}
