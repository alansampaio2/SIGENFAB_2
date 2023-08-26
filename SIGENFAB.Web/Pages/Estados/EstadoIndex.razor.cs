using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;
using SIGENFAB.Web.Repositories;
using System.Diagnostics.Metrics;

namespace SIGENFAB.Web.Pages.Estados
{
    public partial class EstadoIndex
    {
        [Inject] IRepository repository { get; set; }

        public List<Estado>? Estados { get; set; }

        private int currentPage = 1;
        private int totalPages;

        [Parameter]
        [SupplyParameterFromQuery]
        public string Page { get; set; } = "";
        [Parameter]
        [SupplyParameterFromQuery]
        public string Filter { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task LoadAsync(int page = 1)
        {
            if (!string.IsNullOrWhiteSpace(Page))
            {
                page = Convert.ToInt32(Page);
            }
            string url1 = string.Empty;
            string url2 = string.Empty;
            if (string.IsNullOrEmpty(Filter))
            {
                url1 = $"api/estados?page={page}";
                url2 = $"api/estados/totalPages";
            }
            else
            {
                url1 = $"api/estados?page={page}&filter={Filter}";
                url2 = $"api/estados/totalPages?filter={Filter}";
            }

            try
            {
                var responseHppt = await repository.Get<List<Estado>>(url1);
                var responseHppt2 = await repository.Get<int>(url2);
                Estados = responseHppt.Response!;
                totalPages = responseHppt2.Response!;
            }
            catch (Exception ex)
            {
                await sweetAlertService.FireAsync("Error", ex.Message, SweetAlertIcon.Error);
            }
            

            //var responseHttp = await repository.Get<List<Estado>>("api/estados");
            //Estados = responseHttp.Response!;
        }

        private async Task SelectedPage(int page)
        {
            currentPage = page;
            await LoadAsync(page);
        }

        private async Task Delete(Estado estado)
        {
            var result = await sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmação",
                Text = "Está certo de que deseja realmente excluir este registro?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true
            });
            var confirm = string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }
            var responseHTTP = await repository.Delete($"api/estados/{estado.Id}");
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
                await LoadAsync();
            }
        }

        private async Task CleanFilterAsync()
        {
            Filter = string.Empty;
            await ApplyFilterAsync();
        }
        private async Task ApplyFilterAsync()
        {
            int page = 1;
            await LoadAsync(page);
            await SelectedPage(page);
        }
    }
}
