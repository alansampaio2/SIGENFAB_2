using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Area
    {
        public int Id { get; set; }

        [Display(Name = "Unidade de Saúde")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione a Unidade de Saúde")]
        public int UnidadeId { get; set; }

        [Display(Name = "INE")]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string INE { get; set; } = null!;

        [Display(Name = "Nome")]
        [MaxLength(30, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Descrição")]
        [MaxLength(30, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; } = null!;

        public Unidade? Unidade { get; set; }
        public ICollection<Micro>? Micros { get; set; }
        public ICollection<TecEnfermagem>? TecsEnfermagem { get; set; }
        public ICollection<Enfermeiro>? Enfermeiros { get; set; }


        public int TotalDeMicros()
        {
            return Micros == null ? 0 : Micros.Count;
        }
        public int TotalDeDomicilios()
        {
            return Micros == null ? 0 : Micros.Sum(x => x.TotalDeDomicilios());
        }
        //public int TotalDePacientes()
        //{
        //    return Micros == null ? 0 : Micros.Sum(x => x.TotalDePacientes());
        //}
    }
}