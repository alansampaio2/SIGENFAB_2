using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Enums
{
    public enum StatusMercadoDeTrabalho
    {
        [Display(Name = "Nenhum(a)")]
        NENHUM = 0,
        [Display(Name = "Empregador(a)")]
        EMPREGADOR = 1,
        [Display(Name = "Assalariado com Carteira Assinada")]
        ASSALARIADO_COM_CARTEIRA = 2,
        [Display(Name = "Assalariado sem Carteira Assinada")]
        ASSALARIADO_SEM_CARTEIRA = 3,
        [Display(Name = "Autônomo com Previdência Social")]
        AUTONOMO_COM_PREVIDENCIA = 4,
        [Display(Name = "Autônomo sem Previdência Social")]
        AUTONOMO_SEM_PREVIDENCIA = 5,
        [Display(Name = "Aposentado/Pensinista")]
        APOSENTADO_PENSIONISTA = 6,
        [Display(Name = "Desempregado(a)")]
        DESEMPREADO = 7,
        [Display(Name = "Não Trabalha")]
        NAO_TRABALHA = 8,
        [Display(Name = "Servidor Público/Militar")]
        SERVIDOR_PUBLICO_MILITAR = 9,
        [Display(Name = "Outro")]
        OUTRO = 10,
    }
}
