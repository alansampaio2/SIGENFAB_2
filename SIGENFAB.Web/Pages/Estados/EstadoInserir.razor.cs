using SIGENFAB.Shared.Entities;

namespace SIGENFAB.Web.Pages.Estados
{
    public partial class EstadoInserir
    {
        public Estado? Estado { get; set; } = new();
        private EstadoForm? estadoForm;

        private async Task Create()
        {
            var responseHttp = await repositorio.Post("api/estados", Estado);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message);
                return;
            }
            else
            {
                estadoForm!.FormPostedSuccessfully = true;
                navigationManager.NavigateTo("/estados");
            }
        }

        private void Return()
        {
            navigationManager.NavigateTo("/estados");
        }
    }
}
