using SIGENFAB.Shared.Entities;

namespace SIGENFAB.Web.Pages.Deficiencias
{
    public partial class DeficienciaInserir
    {
        public Deficiencia? Deficiencia { get; set; } = new();
        private DeficienciaForm? deficienciaForm;

        private async Task Create()
        {
            var responseHttp = await repositorio.Post("api/deficiencias", Deficiencia);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message);
                return;
            }
            else
            {
                deficienciaForm!.FormPostedSuccessfully = true;
                navigationManager.NavigateTo("/deficiencias");
            }            
        }

        private void Return()
        {
            navigationManager.NavigateTo("/deficiencias");
        }
    }
}
