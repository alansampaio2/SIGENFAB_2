using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Cidade
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; } = null!;

        public int EstadoId { get; set; }

        public Estado? Estado { get; set; }

        public ICollection<Bairro>? Bairros { get; set; }

        [Display(Name = "Bairros")]
        public int NumeroBairros => Bairros == null ? 0 : Bairros.Count;
    }
}
