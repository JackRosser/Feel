using Feel.Components;
using Feel.Service.ChangeStateHelper;
using Feel.Service.Proxy;
using Feel.Shared.Dto.Obiettivi;
using Feel.Shared.Enum;

namespace Feel.Pages
{
    public partial class DashBoard(ProxyObiettivi sdk, ObiettiviStateService stato) : MainClassBase
    {
        private IEnumerable<ObiettivoDto>? Obiettivi { get; set; }
        private IEnumerable<ObiettivoDto>? ObiettiviFiltrati { get; set; }

        private Func<Task>? _handler;

        protected override async Task OnInitializedAsync()
        {
            _handler = OnObiettiviAggiornati;
            stato.ObiettiviAggiornati += _handler;
            await GetRecords();
        }

        private async Task ClearAllFromAdmin()
        {
            await sdk.SendRequestAsync(a => a.ClearAllDb());
            NavManager.NavigateTo("/", forceLoad: true);
        }

        private async Task GetRecords()
        {
            await Task.Delay(1000);
            Obiettivi = new List<ObiettivoDto>
    {
        new()
        {
            Id = 1,
            Categoria = Category.Risparmio,
            Titolo = "Risparmiare per le vacanze",
            Descrizione = "Mettere da parte 500€ entro fine estate",
            DataCreazione = DateOnly.FromDateTime(DateTime.Today.AddDays(-30)),
            Scadenza = DateOnly.FromDateTime(DateTime.Today.AddDays(60)),
            DataCompletamento = null,
            Completed = false,
            Target = 500,
            CheckMark = false,
            Progressivo = 150
        },
        new()
        {
            Id = 2,
            Categoria = Category.Salute,
            Titolo = "Perdere 5 kg",
            Descrizione = "Obiettivo salute entro 3 mesi",
            DataCreazione = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)),
            Scadenza = DateOnly.FromDateTime(DateTime.Today.AddDays(80)),
            DataCompletamento = null,
            Completed = false,
            Target = 5,
            CheckMark = false,
            Progressivo = 1
        },
        new()
        {
            Id = 3,
            Categoria = Category.Cultura,
            Titolo = "Leggere 10 libri",
            Descrizione = "Sfida personale annuale",
            DataCreazione = DateOnly.FromDateTime(new DateTime(DateTime.Today.Year, 1, 1)),
            Scadenza = DateOnly.FromDateTime(new DateTime(DateTime.Today.Year, 12, 31)),
            DataCompletamento = null,
            Completed = false,
            Target = 10,
            CheckMark = false,
            Progressivo = 4
        },
        new()
        {
            Id = 4,
            Categoria = Category.Tecnologia,
            Titolo = "Completare corso su Blazor",
            Descrizione = "Studio su MudBlazor e componenti personalizzati",
            DataCreazione = DateOnly.FromDateTime(DateTime.Today.AddDays(-45)),
            Scadenza = DateOnly.FromDateTime(DateTime.Today.AddDays(15)),
            DataCompletamento = null,
            Completed = false,
            Target = 100,
            CheckMark = false,
            Progressivo = 75
        }
    };

            ObiettiviFiltrati = Obiettivi;
            StateHasChanged();
        }


        //private async Task GetRecords()
        //{
        //    Obiettivi = await sdk.SendRequestAsync(a => a.GetAllObiettiviAsync());
        //    ObiettiviFiltrati = Obiettivi;
        //    StateHasChanged();
        //}

        private Task OnObiettiviAggiornati() => GetRecords();

        private void AggiornaListaFiltrata(IEnumerable<ObiettivoDto> lista)
        {
            ObiettiviFiltrati = lista;
            StateHasChanged();
        }

        protected override void OnDispose()
        {
            if (_handler is not null)
                stato.ObiettiviAggiornati -= _handler;
        }
    }
}




