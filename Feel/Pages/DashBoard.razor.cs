using Feel.Components;
using Feel.Service.ChangeStateHelper;
using Feel.Service.Proxy;
using Feel.Shared.Dto.Obiettivi;

namespace Feel.Pages
{
    public partial class DashBoard(ProxyObiettivi sdk, ObiettiviStateService stato) : MainClassBase
    {
        private IEnumerable<ObiettivoDto>? Obiettivi { get; set; }

        private Func<Task>? _handler;

        protected override async Task OnInitializedAsync()
        {
            _handler = OnObiettiviAggiornati;
            stato.ObiettiviAggiornati += _handler;
            await GetRecords();
        }

        private async Task OnObiettiviAggiornati()
        {
            await GetRecords();
        }

        private async Task GetRecords()
        {
            // QUESTO SERVE SOLO PER TEST DI OBIETTIVO COMPLETATO


            //var nuovo = new ObiettivoDto
            //{
            //    Categoria = Category.Salute,
            //    Titolo = "Test Obiettivo Completato",
            //    Descrizione = "Questo è un obiettivo di test già completato.",
            //    DataCreazione = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)),
            //    Scadenza = DateOnly.FromDateTime(DateTime.Today),
            //    DataCompletamento = DateOnly.FromDateTime(DateTime.Today),
            //    Completed = true,
            //    Target = 10,
            //    Progressivo = 10,
            //    CheckMark = true
            //};
            //await sdk.SendRequestAsync(a => a.CreateTestingNewObiettivoAsync(nuovo));
            Obiettivi = await sdk.SendRequestAsync(a => a.GetAllObiettiviAsync());
            StateHasChanged();
        }


        protected override void OnDispose()
        {
            if (_handler is not null)
                stato.ObiettiviAggiornati -= _handler;
        }
    }
}
