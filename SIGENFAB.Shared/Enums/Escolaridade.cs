using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Enums
{
    public enum Escolaridade
    {
        [Display(Name = "Nenhum(a)")]
        [Description("Nenhum")]
        NENHUM = 0,
        [Display(Name = "Anafalbeto(a)")]
        ANALFABETO = 1,
        [Display(Name = "Alfabetizado(a)")]
        ALFABETIZADO = 2,
        [Display(Name = "Ensino Fundamental Incompleto")]
        FUNDAMENTAL_INCOMPLETO = 3,
        [Display(Name = "Ensino Fundamental Completo")]
        FUNDAMENTAL_COMPLETO = 4,
        [Display(Name = "Ensino Médio Incompleto")]
        MEDIO_INCOMPLETO = 5,
        [Display(Name = "Ensino Médio Completo")]
        MEDIO_COMPLETO = 6,
        [Display(Name = "Ensino Superior Incompleto")]
        SUPERIOR_INCOMPLETO = 7,
        [Display(Name = "Ensino Superior Completo")]
        SUPERIOR_COMPLETO = 8,
        [Display(Name = "Pós-Graduação")]
        POSGRADUACAO = 9,
        [Display(Name = "Mestrado")]
        MESTRE = 10,
        [Display(Name = "Doutorado")]
        DOUTOR = 11
    }
}
