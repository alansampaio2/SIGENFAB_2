using System.ComponentModel;

namespace SIGENFAB.Shared.Enums
{
    public enum EstadoCivil
    {
        [Description("Nenhum(a)")]
        NONE = 0,
        [Description("Solteiro(a)")]
        Solteiro = 1,
        [Description("União Estável")]
        Uniao_Estavel = 2,
        [Description("Casado(a)")]
        Casado = 3,
        [Description("Divorciado(a)")]
        Divorciado = 4,
        [Description("Viúvo(a)")]
        Viuvo = 5,
        [Description("Separado(a)")]
        Separado = 6
    }
}
