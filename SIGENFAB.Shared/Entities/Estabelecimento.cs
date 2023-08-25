using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Estabelecimento : Endereco
    {
        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Descrição")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; } = null!;

        [Display(Name = "Observações")]
        [MaxLength(500, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string Observacao { get; set; } = null!;
    }
}
