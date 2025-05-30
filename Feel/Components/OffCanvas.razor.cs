using Feel.Shared.Dto.Obiettivi;
using Microsoft.AspNetCore.Components;

namespace Feel.Components
{
    public partial class OffCanvas
    {
        [CascadingParameter] public string? MainTheme { get; set; }
        private ObiettivoDto? ObiettivoSelezionato { get; set; }
        private bool IsOpen { get; set; } = false;
        public void SetObiettivo(ObiettivoDto obj)
        {
            ObiettivoSelezionato = obj;
            IsOpen = true;
            InvokeAsync(StateHasChanged);
        }
        private void Close()
        {
            IsOpen = false;
            InvokeAsync(StateHasChanged);
        }
    }
}
