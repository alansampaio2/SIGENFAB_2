using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Unidade : Endereco
    {
        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Display(Name = "CNES")]
        [MaxLength(10, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CNES { get; set; } = null!;

        [Display(Name = "Email")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [EmailAddress(ErrorMessage = "Degite Email válido!")]
        public string Email { get; set; } = null!;

        [Display(Name = "Telefone")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string Telefone { get; set; } = null!;

        [Display(Name = "WhatsApp")]
        [MaxLength(15, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string WhatsApp { get; set; } = null!;

        [Display(Name = "WhatsApp")]
        [MaxLength(15, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string Celular { get; set; } = null!;

        public List<Area>? Areas { get; set; }

        public int TotalDeAreas()
        {
            return Areas == null ? 0 : Areas.Count;
        }
        public int TotalDeMicros()
        {
            return Areas == null ? 0 : Areas.Sum(x => x.TotalDeMicros());
        }
        public int TotalDeDomicilios()
        {
            return Areas == null ? 0 : Areas.Sum(x => x.TotalDeDomicilios());
        }
        //public int TotalDePacientes()
        //{
        //    return Areas == null ? 0 : Areas.Sum(x => x.TotalDePacientes());
        //}
    }
}
