using Microsoft.AspNetCore.Components;

namespace Feel.Components
{
    /// <summary>
    /// Componente per le card in home
    /// </summary>
    public partial class ProgressCard
    {
        [CascadingParameter] public string? MainTheme { get; set; }

    }
}
