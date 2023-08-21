using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;
using System.Net;

namespace SIGENFAB.Web.Pages.Bairros
{
    public partial class BairroDetalhe
    {
        private Bairro? bairro;
        private List<Logradouro>? logradouros;

        [Parameter]
        public int BairroId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }
        private async Task LoadAsync()
        {
            var responseHttp = await repositorio.Get<Bairro>($"api/bairros/{BairroId}");
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
            bairro = responseHttp.Response;
            logradouros = bairro!.Logradouros!.ToList();
        }
        private async Task DeleteAsync(int logradouroId)
        {
            var result = await sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmação",
                Text = "Você realmente deseja excluir o registro?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                CancelButtonText = "Não",
                ConfirmButtonText = "Sim"
            });
            var confirm = string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }
            var responseHttp = await repositorio.Delete($"api/logradouros/{logradouroId}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode != HttpStatusCode.NotFound)
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                    return;
                }
            }
            await LoadAsync();
        }
    }
}
