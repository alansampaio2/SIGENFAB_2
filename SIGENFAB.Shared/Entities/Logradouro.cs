using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Logradouro
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; } = null!;

        [Display(Name = "CEP")]
        [MaxLength(10, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CEP { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int BairroId { get; set; }

        public Bairro? Bairro { get; set; }
    }
}
