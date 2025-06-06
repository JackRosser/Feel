using Feel.Service.ChangeStateHelper;
using Feel.Service.Proxy;
using Feel.Shared.Dto.Obiettivi;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Feel.Components.AssistantChoices
{
    public partial class AddObiettivo(ProxyObiettivi sdk, ObiettiviStateService stato) : MainClassBase
    {
        [Parameter, EditorRequired] public int ModalId { get; set; }
        private CreateObiettivoDto? CreateObiettivo { get; set; }

        public void StartForm()
        {
            CreateObiettivo = new();
            CreateObiettivo.DataCreazione = DateOnly.FromDateTime(DateTime.Now);
            InvokeAsync(StateHasChanged);
        }
        private async Task Save()
        {
            if (CreateObiettivo is null) return;
            await sdk.SendRequestAsync(a => a.CreateNewObiettivoAsync(CreateObiettivo));
            await JS.InvokeVoidAsync("closeModalById", ModalId);
            await stato.NotificaAggiornamentoAsync();
        }


    }
}
