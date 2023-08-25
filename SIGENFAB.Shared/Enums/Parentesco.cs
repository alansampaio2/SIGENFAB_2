using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGENFAB.Shared.Enums
{
    public enum Parentesco
    {
        [Description("Nenhum(a)")]
        CONJUGE = 1,
        [Description("Companheiro(a)")]
        COMPANHEIRO = 2,
        [Description("Filho(a)")]
        FILHO = 3,
        [Description("Enteado(a)")]
        ENTEADO = 4,
        [Description("Neto(a)")]
        NETO = 5,
        [Description("Bisneto(a)")]
        BISNETO = 6,
        [Description("Pai")]
        PAI = 7,
        [Description("Mãe")]
        MAE = 8,
        [Description("Sogro(a)")]
        SOGRO = 9,
        [Description("Irmão(ã)")]
        IRMAO = 10,
        [Description("Genro/Nora")]
        GENRO_NORA = 11,
        [Description("Outro Parente")]
        OUTRO_PARENTE = 12,
        [Description("Não Parente")]
        NAO_PARENTE = 13,
        [Description("O Próprio")]
        O_PROPRIO = 14
    }
}
