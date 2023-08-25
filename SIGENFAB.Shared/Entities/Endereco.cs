using SIGENFAB.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Endereco
    {
        public int Id { get; set; }

        [Display(Name = "Logradouro")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione o Logradouro")]
        public int LogradouroId { get; set; }

        [Display(Name = "Complemento")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string Complemento { get; set; } = null!;

        [Display(Name = "Número")]
        [MaxLength(15, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string Numero { get; set; } = null!;
        public bool SemNumero { get; set; } = false;
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        [Display(Name = "Tipo de Imóvel")]
        [Range(0, int.MaxValue, ErrorMessage = "Selecione o Tipo de Imóvel")]
        public ImovelTipo ImovelTipo { get; set; }

        [Display(Name = "Ponto de Referencia")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string PontoDeReferencia { get; set; } = null!;

        public Logradouro? Logradouro { get; set; }
    }
}
