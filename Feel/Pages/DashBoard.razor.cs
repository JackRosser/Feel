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
