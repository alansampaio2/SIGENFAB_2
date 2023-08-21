using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;
using System.Net;

namespace SIGENFAB.Web.Pages.Cidades
{
    public partial class CidadeEditar
    {
        private Cidade? cidade;
        private CidadeForm? cidadeForm;

        [Parameter]
        public int CidadeId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await repositorio.Get<Cidade>($"api/cidades/{CidadeId}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo("/estados");
                    return;
                }
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            cidade = responseHttp.Response;
        }
        private async Task EditAsync()
        {
            var responseHttp = await repositorio.Put("api/cidades", cidade);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            Return();
        }
        private void Return()
        {
            cidadeForm!.FormPostedSuccessfully = true;
            navigationManager.NavigateTo($"/estados/detalhes/{cidade!.EstadoId}");
        }
    }
}
