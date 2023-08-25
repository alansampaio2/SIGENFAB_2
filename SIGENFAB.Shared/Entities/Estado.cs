using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Estado
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; } = null!;

        [Display(Name = "Sigla")]
        [MaxLength(2, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Sigla { get; set; } = null!;

        public ICollection<Cidade>? Cidades { get; set; }

        [Display(Name = "Cidades")]
        public int NumeroCidades => Cidades == null ? 0 : Cidades.Count;
        public int NumeroBairros => Cidades == null ? 0 : Cidades.Sum(x => x.NumeroBairros);
    }
}
