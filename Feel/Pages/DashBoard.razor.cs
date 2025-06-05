using Feel.Components;
using Feel.Service.ChangeStateHelper;
using Feel.Service.Proxy;
using Feel.Shared.Dto.Obiettivi;

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
            Obiettivi = await sdk.SendRequestAsync(a => a.GetAllObiettiviAsync());
            ObiettiviFiltrati = Obiettivi;
            StateHasChanged();
        }

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




