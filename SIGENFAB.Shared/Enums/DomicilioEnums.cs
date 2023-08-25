using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Enums
{
    public enum StatusDomicilio
    {
        [Display(Name = "Próprio")]
        PROPRIO = 1,
        [Display(Name = "Financiado")]
        FINANCIADO = 2,
        [Display(Name = "Alugado")]
        ALUGADO = 3,
        [Display(Name = "Arrendado")]
        ARRENDADO = 4,
        [Display(Name = "Cedido")]
        CEDIDO = 5,
        [Display(Name = "Ocupação")]
        OCUPACAO = 6,
        [Display(Name = "Outro")]
        OUTRO = 7
    }
    public enum Localizacao
    {
        [Display(Name = "Urbana")]
        URBANA = 1,
        [Display(Name = "Rural")]
        RURAL = 2
    }

    public enum TipoDeMaterial
    {
        [Display(Name = "Alvenaria/Tijolo com Revestimento")]
        ALVENARIA_TIJOLO_COM_REVESTIMENTO = 1,
        [Display(Name = "Alvenaria/Tijolo sem Revestimento")]
        ALVENARIA_TIJOLO_SEM_REVESTIMENTO = 2,
        [Display(Name = "Taipa com Revestimento")]
        TAIPA_COM_REVESTIMENTO = 3,
        [Display(Name = "Taipa sem Revestimento")]
        TAIPA_SEM_REVESTIMENTO = 4,
        [Display(Name = "Madeira Aparelhada")]
        MADEIRA_APARELHADA = 5,
        [Display(Name = "Material Aproveitado")]
        MATERIAL_APROVEITADO = 6,
        [Display(Name = "Palha")]
        PALHA = 7,
        [Display(Name = "Outro Material")]
        OUTRO_MATERIAL = 8
    }

    public enum TipoDeDomicilio
    {
        [Display(Name = "Casa")]
        CASA = 1,
        [Display(Name = "Apartamento")]
        CONDOMINIO_APARTAMENTO = 2,
        [Display(Name = "Cômodo")]
        CONDOMINIO_CASA = 3,
        RESIDENCIAL = 4,
        VILA = 5,
        [Display(Name = "Outro")]
        OUTRO = 6
    }

    public enum AcessoAoDomicilio
    {
        [Display(Name = "Pavimento")]
        PAVIMENTO = 1,
        [Display(Name = "Chão Batido")]
        CHAO_BATIDO = 2,
        [Display(Name = "Fluvial")]
        FLUVIAL = 3,
        [Display(Name = "Outro")]
        OUTRO = 4
    }

    public enum AbastecimentoDeAgua
    {
        [Display(Name = "Rede Encanada")]
        REDE_ENCANADA = 1,
        [Display(Name = "Carro Pipa")]
        CARRO_PIPA = 2,
        [Display(Name = "Poço ou Nascente")]
        POCO_NASCENTE = 3,
        CISTERNA = 4,
        [Display(Name = "Outro")]
        OUTRO = 5
    }

    public enum TratamentoDeAgua
    {
        [Display(Name = "Filtração")]
        FILTRACAO = 1,
        [Display(Name = "Fervura")]
        FERVURA = 2,
        [Display(Name = "Cloração")]
        CLORACAO = 3,
        [Display(Name = "Sem Tratamento")]
        SEM_TRATAMENTO = 4
    }

    public enum Esgoto
    {
        [Display(Name = "Rede Coletora de Esgoto Pluvial")]
        REDE_COLETORA_ESGOTO_PLUVIAL = 1,
        [Display(Name = "Direto Para Rio/Lagoa/Mar")]
        DIRETO_PARA_RIO_LAGOA_MAR = 2,
        [Display(Name = "Fossa Séptica")]
        FOSSA_SEPTICA = 3,
        [Display(Name = "Céu Aberto")]
        CEU_ABERTO = 4,
        [Display(Name = "Foça Rudimentar")]
        FOSSA_RUDIMENTAR = 5,
        [Display(Name = "Outro")]
        OUTRO = 6
    }

    public enum Lixo
    {
        [Display(Name = "Coletado")]
        COLETADO = 1,
        [Display(Name = "Queimado/Enterrado")]
        QUEIMADO_ENTERRADO = 2,
        [Display(Name = "Céu Aberto")]
        CEU_ABERTO = 3,
        [Display(Name = "Outro")]
        OUTRO = 4
    }
}
