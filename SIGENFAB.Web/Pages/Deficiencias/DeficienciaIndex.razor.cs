using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;
using SIGENFAB.Web.Repositories;

namespace SIGENFAB.Web.Pages.Deficiencias
{
    public partial class DeficienciaIndex
    {
        [Inject] IRepository repository { get; set; }

        public List<Deficiencia>? Deficiencias { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Load();
        }

        private async Task Load()
        {
            var responseHttp = await repository.Get<List<Deficiencia>>("api/deficiencias");
            Deficiencias = responseHttp.Response!;
        }

        private async Task Delete(Deficiencia deficiencia)
        {
            var result = await sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmação",
                Text = "Está certe de que deseja realmente excluir este registro?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true
            });
            var confirm = string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }
            var responseHTTP = await repository.Delete($"api/deficiencias/{deficiencia.Id}");
            if (responseHTTP.Error)
            {
                if (responseHTTP.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo("/");
                }
                else
                {
                    var mensajeError = await responseHTTP.GetErrorMessageAsync();
                    await sweetAlertService.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
                }
            }
            else
            {
                await Load();
            }
        }
    }
}
