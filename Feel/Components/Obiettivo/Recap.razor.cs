using Feel.Resources;
using Feel.Shared.Dto.Obiettivi;
using Microsoft.AspNetCore.Components;

namespace Feel.Components.Obiettivo
{
    public partial class Recap : MainClassBase
    {
        [Parameter, EditorRequired] public ObiettivoDto? Obiettivo { get; set; }

        private List<RecapElement>? RecapElements { get; set; }

        protected override void OnParametersSet()
        {
            RecapElements = new()
            {
                new() { Title = Localizer[ResourceLanguage.Target], Value = Obiettivo?.Target.ToString() },
                new() { Title = Localizer[ResourceLanguage.Attuale], Value = Obiettivo?.Progressivo.ToString() },
                new() { Title = Localizer[ResourceLanguage.TermineObiettivo], Value = $"{Localizer[ResourceLanguage.Mancano]} {CalcoloGiorniScadenza(Obiettivo?.Scadenza)} {Localizer[ResourceLanguage.GiorniScadenza]}"},
            };
        }

        private int CalcoloGiorniScadenza(DateOnly? scadenza)
        {
            if (scadenza is null)
                return 0;

            var today = DateOnly.FromDateTime(DateTime.Now);
            return (scadenza.Value.DayNumber - today.DayNumber);
        }


        private class RecapElement()
        {
            public string? Title { get; set; }
            public string? Value { get; set; }

        }
    }
}
