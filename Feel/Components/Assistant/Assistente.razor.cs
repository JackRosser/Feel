namespace Feel.Components.Assistant
{
    public partial class Assistente : MainClassBase
    {

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

        private void SitAssistant()
        {
            IsSelected = false;
        }

    }
}
