using Feel.Service.ChangeStateHelper;
using Feel.Service.Proxy;
using Feel.Shared.Dto.Obiettivi;

namespace Feel.Components.Obiettivo
{
    public partial class AddObiettivo(ProxyObiettivi sdk, ObiettiviStateService stato) : MainClassBase
    {
        private CreateObiettivoDto? CreateObiettivo { get; set; }

        public void StartForm()
        {
            if (CreateObiettivo is null)
            {
                CreateObiettivo = new();
                CreateObiettivo.DataCreazione = DateOnly.FromDateTime(DateTime.Now);
            }
            InvokeAsync(StateHasChanged);
        }
        private async Task Save()
        {
            if (CreateObiettivo is null) return;

            await sdk.SendRequestAsync(a => a.CreateNewObiettivoAsync(CreateObiettivo));
            await stato.NotificaAggiornamentoAsync();

        }

    }
}
