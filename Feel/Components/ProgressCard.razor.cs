using Feel.Shared.Dto.Obiettivi;
using Feel.Shared.Enum;
using Microsoft.AspNetCore.Components;

namespace Feel.Components
{
    /// <summary>
    /// Componente per le card in home
    /// </summary>
    public partial class ProgressCard
    {
        [CascadingParameter] public string? MainTheme { get; set; }

        private ViewModel Model = new();

        private OffCanvas _offCanvas { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1000);
            Model.Obiettivi = new List<ObiettivoDto>
            {
                new ObiettivoDto { Id = 0, Categoria = Category.Risparmio, Titolo = "Risparmiare 100 euro", Descrizione = "Voglio risparmiare 100 euro per comprarmi una Panda", Scadenza = new DateOnly(2025, 5, 15) },
                new ObiettivoDto { Id = 1, Categoria = Category.Sport, Titolo = "Perdere 10kg", Scadenza = new DateOnly(2025, 10, 12) },
                new ObiettivoDto { Id = 2, Categoria = Category.Animali, Titolo = "Comprare un cane", Descrizione = "VVoglio comprare un cane per farmi compagnia", Scadenza = new DateOnly(2025, 12, 31) },
                new ObiettivoDto { Id = 3, Categoria = Category.Animali, Titolo = "Il mio scopo è 20 car", Descrizione = "VVoglio comprare un cane per farmi compagnia", Scadenza = new DateOnly(2025, 12, 31) },
                new ObiettivoDto { Id = 0, Categoria = Category.Risparmio, Titolo = "Risparmiare 100 euro", Descrizione = "Voglio risparmiare 100 euro per comprarmi una Panda", Scadenza = new DateOnly(2025, 5, 15) },
                new ObiettivoDto { Id = 1, Categoria = Category.Sport, Titolo = "Perdere 10kg", Scadenza = new DateOnly(2025, 10, 12) },
                new ObiettivoDto { Id = 2, Categoria = Category.Animali, Titolo = "Comprare un cane", Descrizione = "VVoglio comprare un cane per farmi compagnia", Scadenza = new DateOnly(2025, 12, 31) },
                new ObiettivoDto { Id = 3, Categoria = Category.Animali, Titolo = "Il mio scopo è 20 car", Descrizione = "VVoglio comprare un cane per farmi compagnia", Scadenza = new DateOnly(2025, 12, 31) },
                new ObiettivoDto { Id = 0, Categoria = Category.Risparmio, Titolo = "Risparmiare 100 euro", Descrizione = "Voglio risparmiare 100 euro per comprarmi una Panda", Scadenza = new DateOnly(2025, 5, 15) },
                new ObiettivoDto { Id = 1, Categoria = Category.Sport, Titolo = "Perdere 10kg", Scadenza = new DateOnly(2025, 10, 12) },
                new ObiettivoDto { Id = 2, Categoria = Category.Animali, Titolo = "Comprare un cane", Descrizione = "VVoglio comprare un cane per farmi compagnia", Scadenza = new DateOnly(2025, 12, 31) },
                new ObiettivoDto { Id = 3, Categoria = Category.Animali, Titolo = "Il mio scopo è 20 car", Descrizione = "VVoglio comprare un cane per farmi compagnia", Scadenza = new DateOnly(2025, 12, 31) },

            };
        }

        private class ViewModel
        {
            public IEnumerable<ObiettivoDto>? Obiettivi { get; set; }
        }

    }
}
