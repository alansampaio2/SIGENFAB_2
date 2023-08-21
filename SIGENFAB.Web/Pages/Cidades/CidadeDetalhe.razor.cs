using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;
using System.Net;

namespace SIGENFAB.Web.Pages.Cidades
{
    public partial class CidadeDetalhe
    {
        private Cidade? cidade;
        private List<Bairro>? bairros;
        [Parameter]
        public int CidadeId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }
        private async Task LoadAsync()
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
            bairros = cidade!.Bairros!.ToList();
        }
        private async Task DeleteAsync(int bairroId)
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
            var responseHttp = await repositorio.Delete($"api/bairros/{bairroId}");
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
