using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using SIGENFAB.Shared.Entities;

namespace SIGENFAB.Web.Pages.Deficiencias
{
    public partial class DeficienciaForm
    {
        [EditorRequired]
        [Parameter]
        public Deficiencia Deficiencia { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidSubmit { get; set; }

        [EditorRequired]
        [Parameter]
        public EventCallback ReturnAction { get; set; }

        private EditContext editContext = null!;
        public bool FormPostedSuccessfully { get; set; } = false;

        protected override void OnInitialized()
        {
            editContext = new(Deficiencia);
        }

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formWasEdited = editContext.IsModified();
            if (!formWasEdited || FormPostedSuccessfully)
            {
                return;
            }

            var result = await sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmação",
                Text = "Deseja realmente deixar a página e perder as alterações?",
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
