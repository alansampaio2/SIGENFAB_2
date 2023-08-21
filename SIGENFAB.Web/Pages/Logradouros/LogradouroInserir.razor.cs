using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;

namespace SIGENFAB.Web.Pages.Logradouros
{
    public partial class LogradouroInserir
    {
        private Logradouro logradouro = new();
        private LogradouroForm? logradouroForm;

        [Parameter]
        public int BairroId { get; set; }


        private async Task CreateAsync()
        {
            logradouro.BairroId = BairroId;
            var httpResponse = await repositorio.Post("api/logradouros", logradouro);
            if (httpResponse.Error)
            {
                var message = await httpResponse.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            Return();
        }

        private void Return()
        {
            logradouroForm!.FormPostedSuccessfully = true;
            navigationManager.NavigateTo($"/bairros/detalhes/{BairroId}");
        }
    }
}
