using Feel.Components.Obiettivo;
using Feel.Shared.Dto.Obiettivi;
using Microsoft.AspNetCore.Components;

namespace Feel.Components
{
    /// <summary>
    /// Componente per le card in home
    /// </summary>
    public partial class ProgressCard : MainClassBase
    {
        [Parameter, EditorRequired] public ObiettivoDto? Obiettivo { get; set; }
        private string? FillColor { get; set; }
        private string? IsCompleted { get; set; }
        private UpdateObiettivo? _updateObiettivo;
        protected override void OnParametersSet()
        {
            int height = Obiettivo?.Percentage ?? 0;
            string color = height switch
            {
                >= 100 => "green",
                >= 25 and < 50 => "yellow",
                >= 50 and < 100 => "blue",
                _ => "red",
            };
            FillColor = color;
            IsCompleted = Obiettivo?.Completed == true ? "completed" : "";
        }
        private void Action()
        {
            _updateObiettivo?.OpenPopup();
        }

    }
}
