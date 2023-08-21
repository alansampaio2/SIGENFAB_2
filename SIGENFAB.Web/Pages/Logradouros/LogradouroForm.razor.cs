using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using SIGENFAB.Shared.Entities;

namespace SIGENFAB.Web.Pages.Logradouros
{
    public partial class LogradouroForm
    {
        private EditContext editContext = null!;
        [Parameter]
        [EditorRequired]
        public Logradouro Logradouro { get; set; } = null!;
        [Parameter]
        [EditorRequired]
        public EventCallback OnValidSubmit { get; set; }
        [Parameter]
        [EditorRequired]
        public EventCallback ReturnAction { get; set; }
        public bool FormPostedSuccessfully { get; set; }
        protected override void OnInitialized()
        {
            editContext = new(Logradouro);
        }
        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formWasMofied = editContext.IsModified();
            if (!formWasMofied || FormPostedSuccessfully)
            {
                return;
            }
            var result = await sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmação",
                Text = "Deseja sair da página e perder suas alterações?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                CancelButtonText = "Não",
                ConfirmButtonText = "Sim"
            });
            var confirm = !string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }
            context.PreventNavigation();
        }
    }
}
