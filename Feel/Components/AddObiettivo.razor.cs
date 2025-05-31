using Feel.Shared.Dto.Obiettivi;
using Microsoft.AspNetCore.Components;

namespace Feel.Components
{
    public partial class AddObiettivo
    {
        [CascadingParameter(Name = "MainTheme")] public string? MainTheme { get; set; }
        private CreateObiettivoDto? CreateObiettivoForm { get; set; }
        private OffCanvas? _offCanvas { get; set; }

        public void OpenAddObiettivo()
        {
            CreateObiettivoForm = new CreateObiettivoDto();
            _offCanvas?.Open();
        }

        private async Task Save()
        {
            await Task.Delay(1000);
        }
    }
}
