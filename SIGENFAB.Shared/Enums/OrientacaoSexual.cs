using System.ComponentModel;

namespace SIGENFAB.Shared.Enums
{
    public enum OrientacaoSexual
    {
        [Description("Não Informado")]
        NAO_INFORMADO = 0,
        [Description("Heterossexual")]
        HETERESSEXUAL = 1,
        [Description("Homossexual")]
        HOMOSSEXUAL = 2,
        [Description("Bissexual")]
        BISSEXUAL = 3,
        [Description("Outro(a)")]
        OUTRO = 4
    }
}
