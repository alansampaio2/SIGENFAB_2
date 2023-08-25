using System.ComponentModel;

namespace SIGENFAB.Shared.Enums
{
    public enum IdentidadeDeGenero
    {
        [Description("Não Informado")]
        NAO_INFORMADO = 0,
        [Description("Homem Transexual")]
        HOMEM_TRANSEXUAL = 1,
        [Description("Mulher Transexual")]
        MULHER_TRANSEXUAL = 2,
        [Description("Travesti")]
        TRAVESTI = 3,
        [Description("Outro(a)")]
        OUTRO = 4
    }
}
