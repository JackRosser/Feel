using Feel.Components.Obiettivo;
using Feel.Service;
using Feel.Service.ChangeStateHelper;
using Feel.Shared.Dto.Obiettivi;
using Microsoft.AspNetCore.Components;

namespace Feel.Components
{
    public partial class ProgressCard(ObiettivoService obiettivoSdk, ObiettiviStateService stato) : MainClassBase
    {
        [Parameter, EditorRequired] public IEnumerable<ObiettivoDto>? Obiettivi { get; set; }

        private bool DeleteObiettivoToggle { get; set; } = false;

        private void ShowDeleteObiettivi()
        {
            DeleteObiettivoToggle = !DeleteObiettivoToggle;
            InvokeAsync(StateHasChanged);
        }

        public async Task DeleteObiettivo(int id)
        {
            await obiettivoSdk.DeleteObiettivoAsync(id);
            await stato.NotificaAggiornamentoAsync();
        }

        private class RefWrapper
        {
            public UpdateObiettivo? Ref { get; set; }
        }


        private Dictionary<int, RefWrapper> _updateObiettivi = new();


        private async Task ApriPopup(int id)
        {
            if (_updateObiettivi.TryGetValue(id, out var wrapper) && wrapper.Ref is not null)
            {
                await wrapper.Ref.OpenPopup();
            }
        }

    }
}
