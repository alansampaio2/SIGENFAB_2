using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;

namespace SIGENFAB.Web.Pages.Cidades
{
    public partial class CidadeInserir
    {
        private Cidade cidade = new();
        private CidadeForm? cidadeForm;

        [Parameter]
        public int EstadoId { get; set; }
        private async Task CreateAsync()
        {
            cidade.EstadoId = EstadoId;
            var httpResponse = await repositorio.Post("api/cidades", cidade);
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
            cidadeForm!.FormPostedSuccessfully = true;
            navigationManager.NavigateTo($"/estados/detalhes/{EstadoId}");
        }
    }
}
