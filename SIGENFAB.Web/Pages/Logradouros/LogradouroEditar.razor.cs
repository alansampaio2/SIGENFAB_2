using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;
using SIGENFAB.Web.Pages.Bairros;
using System.Net;

namespace SIGENFAB.Web.Pages.Logradouros
{
    public partial class LogradouroEditar
    {
        private Logradouro? logradouro;
        private LogradouroForm? logradouroForm;

        [Parameter]
        public int LogradouroId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await repositorio.Get<Logradouro>($"api/logradouros/{LogradouroId}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo($"/bairros/detalhes/{logradouro!.BairroId}");
                    return;
                }
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            logradouro = responseHttp.Response;
        }
        private async Task EditAsync()
        {
            var responseHttp = await repositorio.Put("api/logradouros", logradouro);
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
            logradouroForm!.FormPostedSuccessfully = true;
            navigationManager.NavigateTo($"/bairros/detalhes/{logradouro!.BairroId}");
        }
    }
}
