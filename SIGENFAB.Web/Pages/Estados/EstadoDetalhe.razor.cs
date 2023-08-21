using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;
using SIGENFAB.Web.Repositories;
using System.Diagnostics.Metrics;
using System.Net;

namespace SIGENFAB.Web.Pages.Estados
{
    public partial class EstadoDetalhe
    {
        [Parameter]
        public int Id { get; set; }

        public Estado? Estado { get; set; }
        public List<Cidade>? Cidades { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task LoadAsync()
        {
            var response = await repositorio.Get<Estado>($"api/estados/{Id}");
            if (response.Error)
            {
                if (response.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo("/estados");
                    return;
                }
                var message = await response.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            Estado = response.Response;
            Cidades = Estado!.Cidades!.ToList();
        }

        private async Task DeleteAsync(int id)
        {
            var result = await sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmação",
                Text = "Realmente deseja excluir este registro?",
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

            var responseHttp = await repositorio.Delete($"api/estados/{id}");
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
