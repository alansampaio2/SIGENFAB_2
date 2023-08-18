using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;

namespace SIGENFAB.Web.Pages.Deficiencias
{
    public partial class DeficienciaEditar
    {
        [Parameter]
        public int Id { get; set; }

        private Deficiencia? deficiencia;
        private DeficienciaForm? deficienciaForm;

        protected override async Task OnInitializedAsync()
        {
            var responseHTTP = await repositorio.Get<Deficiencia>($"api/deficiencias/{Id}");

            if (responseHTTP.Error)
            {
                if (responseHTTP.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo("deficiencias");
                }
                else
                {
                    var messageError = await responseHTTP.GetErrorMessageAsync();
                    await sweetAlertService.FireAsync("Error", messageError, SweetAlertIcon.Error);
                }
            }
            else
            {
                deficiencia = responseHTTP.Response;
            }
        }

        private async Task Edit()
        {
            var responseHTTP = await repositorio.Put("api/deficiencias", deficiencia);
            if (responseHTTP.Error)
            {
                var mensajeError = await responseHTTP.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
            }
            else
            {
                deficienciaForm!.FormPostedSuccessfully = true;
                navigationManager.NavigateTo("deficiencias");
            }
        }

        private void Return()
        {
            navigationManager.NavigateTo("deficiencias");
        }
    }
}
