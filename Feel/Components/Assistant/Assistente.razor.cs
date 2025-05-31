using Microsoft.AspNetCore.Components;

namespace Feel.Components.Assistant
{
    public partial class Assistente
    {
        [CascadingParameter(Name = "MainTheme")] public string? MainTheme { get; set; }
        [CascadingParameter(Name = "Assistente")] public string? AssistenteNome { get; set; }
        private AddObiettivo? _addObiettivo { get; set; }
        private bool IsSelected { get; set; } = false;
        private string IsSelectedClass => IsSelected ? "pancia" : "fronte";
        private string ShowMessages => IsSelected ? "show" : string.Empty;
        private string WhoIs => AssistenteNome switch
        {
            "giulio.png" => "giulio",
            "kitty.png" => "kitty",
            _ => string.Empty
        };
        private void PadOnAssistant()
        {
            IsSelected = !IsSelected;
        }

        private void AddObiettivoPopUp()
        {
            IsSelected = false;
            _addObiettivo?.OpenAddObiettivo();
        }
    }
}
