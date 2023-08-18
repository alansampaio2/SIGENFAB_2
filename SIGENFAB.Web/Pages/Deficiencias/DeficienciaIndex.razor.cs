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
            var responseHttp = await repository.Get<List<Deficiencia>>("api/deficiencias");
            Deficiencias = responseHttp.Response!;
        }
    }
}
