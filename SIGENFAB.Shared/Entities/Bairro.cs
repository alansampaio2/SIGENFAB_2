using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Bairro
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; } = null!;

        public int CidadeId { get; set; }

        public Cidade? Cidade { get; set; }

        public ICollection<Logradouro>? Logradouros { get; set; }

        [Display(Name = "Logradouros")]
        public int NumeroLogrodouros => Logradouros == null ? 0 : Logradouros.Count;
    }
}
