using SIGENFAB.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Entities
{
    public class Domicilio : Endereco
    {
        [Required(ErrorMessage = "Nome é Obrigatório")]
        [Display(Name = "Nº da Família")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Familia { get; set; } = null!;
        public StatusDomicilio StatusDomicilio { get; set; }
        public Localizacao Localizacao { get; set; }
        public TipoDeDomicilio TipoDeDomicilio { get; set; }
        public int NumeroDeComodos { get; set; }
        public AcessoAoDomicilio AcessoAoDomicilio { get; set; }
        public TipoDeMaterial TipoDeMaterial { get; set; }
        public bool EnergiaEletrica { get; set; }
        public AbastecimentoDeAgua AbastecimentoDeAgua { get; set; }
        public TratamentoDeAgua TratamentoDeAgua { get; set; }
        public Esgoto Esgoto { get; set; }
        public Lixo Lixo { get; set; }
        public bool AnimaisDomicilio { get; set; }
    }
}