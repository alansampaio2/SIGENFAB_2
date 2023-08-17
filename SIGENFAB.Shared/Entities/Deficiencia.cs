using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Deficiencia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é Obrigatório")]
        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Descrição")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        public string Descricao { get; set; } = null!;
    }
}
