using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;
using SIGENFAB.Web.Pages.Cidades;

namespace SIGENFAB.Web.Pages.Bairros
{
    public partial class BairroInserir
    {
        private Bairro bairro = new();
        private BairroForm? bairroForm;

        [Parameter]
        public int CidadeId { get; set; }
        private async Task CreateAsync()
        {
            bairro.CidadeId = CidadeId;
            var httpResponse = await repositorio.Post("api/bairros", bairro);
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
            bairroForm!.FormPostedSuccessfully = true;
            navigationManager.NavigateTo($"/cidades/detalhes/{CidadeId}");
        }
    }
}
