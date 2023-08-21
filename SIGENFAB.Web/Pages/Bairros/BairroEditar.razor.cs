using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;
using System.Net;

namespace SIGENFAB.Web.Pages.Bairros
{
    public partial class BairroEditar
    {
        private Bairro? bairro;
        private BairroForm? bairroForm;

        [Parameter]
        public int BairroId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await repositorio.Get<Bairro>($"api/bairros/{BairroId}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo($"/cidades/detalhes/{bairro!.CidadeId}");
                    return;
                }
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            bairro = responseHttp.Response;
        }
        private async Task EditAsync()
        {
            var responseHttp = await repositorio.Put("api/bairros", bairro);
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
            bairroForm!.FormPostedSuccessfully = true;
            navigationManager.NavigateTo($"/cidades/detalhes/{bairro!.CidadeId}");
        }
    }
}
