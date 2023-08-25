using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Enums
{
    public enum RacaCor
    {
        [Display(Name = "Nenhum(a)")]
        NENHUM = 0,
        [Display(Name = "Branco(a)")]
        BRANCA = 1,
        [Display(Name = "Preto(a)")]
        PRETA = 2,
        [Display(Name = "Pardo(a)")]
        PARDA = 3,
        [Display(Name = "Amarelo(a)")]
        AMARELA = 4,
        [Display(Name = "Indígena")]
        INDIGENA = 5
    }
}
