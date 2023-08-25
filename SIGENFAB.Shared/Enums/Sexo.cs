using System.ComponentModel.DataAnnotations;

namespace SIGENFAB.Shared.Enums
{
    public enum Sexo
    {
        [Display(Name = "Nenhum(a)")]
        NENHUM,
        [Display(Name = "Feminino")]
        FEMININO,
        [Display(Name = "Masculino")]
        MASCULINO
    }
}
