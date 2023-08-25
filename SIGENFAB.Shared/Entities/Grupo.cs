using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Grupo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é Obrigatório")]
        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Descrição")]
        [MaxLength(500, ErrorMessage = "Máximo de 500 caracteres")]
        public string Descricao { get; set; } = null!;
    }
}
