using SIGENFAB.Shared.Enums;
using SIGENFAB.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Paciente : IPessoa
    {
        public int Id { get; set; }
        public Usuario? Usuario { get; set; }

        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Sobrenome")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Sobrenome { get; set; } = null!;

        [Display(Name = "CPF")]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CPF { get; set; } = null!;

        [Display(Name = "CNS")]
        [MaxLength(25, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CNS { get; set; } = null!;

        [Display(Name = "Data de Nascimento")]
        [MaxLength(25, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime Nascimento { get; set; }

        public Sexo Sexo { get; set; }

        [Display(Name = "Nome Social")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string NomeSocial { get; set; } = null!;
        public RacaCor RacaCor { get; set; }

        [Display(Name = "NIS()PIS/PASEP")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string NIS { get; set; } = null!;

        [Display(Name = "Nome da Mãe")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Mae { get; set; } = null!;

        [Display(Name = "Nome do Pai")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string Pai { get; set; } = null!;

        [Display(Name = "Ocupação")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string Ocupacao { get; set; } = null!;
        public bool FrequentaEscola { get; set; } = false;
        public bool FrequentaCreche { get; set; } = false;
        public EstadoCivil EstadoCivil { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public StatusMercadoDeTrabalho StatusMercadoDeTrabalho { get; set; }
        public bool PlanoDeSaude { get; set; } = false;
        public OrientacaoSexual OrientacaoSexual { get; set; }
        public IdentidadeDeGenero IdentidadeDeGenero { get; set; }
        public DateTime? DataObito { get; set; }
        public bool Obito { get; set; } = false;

        [Display(Name = "Declaração de Óbito")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string? DeclaracaoObito { get; set; } = null!;

        [Display(Name = "Motivo do Óbito")]
        [MaxLength(250, ErrorMessage = "O campo {0} deve ter ao máximo {1} caracteres.")]
        public string? MotivoObito { get; set; } = null!;

        public ICollection<Antropometria>? Antropometrias { get; set; }
    }
}
