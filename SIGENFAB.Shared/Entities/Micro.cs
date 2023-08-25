using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Micro
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [MaxLength(10, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; } = null!;

        [Display(Name = "Área")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione a Área")]
        public int AreaId { get; set; }

        public Area? Area { get; set; }

        public ICollection<Domicilio>? Domicilios { get; set; }
        public ICollection<AgenteSaude>? AgentesDeSaude { get; set; }

        public int TotalDeDomicilios()
        {
            return Domicilios == null ? 0 : Domicilios.Count;
        }

        //public int TotalDePacientes()
        //{
        //    return Domicilios == null ? 0 : Domicilios.Sum(x => x.TotalDePacientes());
        //}
    }
}