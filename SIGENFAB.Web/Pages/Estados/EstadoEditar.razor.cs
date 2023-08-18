using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;
using SIGENFAB.Web.Pages.Deficiencias;

namespace SIGENFAB.Web.Pages.Estados
{
    public partial class EstadoEditar
    {
        [Parameter]
        public int Id { get; set; }

        private Estado? estado;
        private EstadoForm? estadoForm;

        protected override async Task OnInitializedAsync()
        {
            var responseHTTP = await repositorio.Get<Estado>($"api/estados/{Id}");

            if (responseHTTP.Error)
            {
                if (responseHTTP.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo("estados");
                }
                else
                {
                    var messageError = await responseHTTP.GetErrorMessageAsync();
                    await sweetAlertService.FireAsync("Error", messageError, SweetAlertIcon.Error);
                }
            }
            else
            {
                estado = responseHTTP.Response;
            }
        }

        private async Task Edit()
        {
            var responseHTTP = await repositorio.Put("api/estados", estado);
            if (responseHTTP.Error)
            {
                var mensajeError = await responseHTTP.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
            }
            else
            {
                estadoForm!.FormPostedSuccessfully = true;
                navigationManager.NavigateTo("estados");
            }
        }

        private void Return()
        {
            navigationManager.NavigateTo("estados");
        }
    }
}
