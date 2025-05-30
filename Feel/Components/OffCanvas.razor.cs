using Microsoft.AspNetCore.Components;

namespace Feel.Components
{
    public partial class OffCanvas
    {
        [CascadingParameter] public string? MainTheme { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }
        private bool IsOpen { get; set; } = false;
        private string IsOpenClass => IsOpen ? "show" : string.Empty;
        public void Open()
        {
            IsOpen = true;
        }
        private void Close()
        {
            IsOpen = false;
        }
    }
}
