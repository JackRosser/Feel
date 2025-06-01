using Feel.Service.ChangeStateHelper;
using Feel.Service.Proxy;
using Feel.Shared.Dto.Obiettivi;
using Microsoft.AspNetCore.Components;

namespace Feel.Components.Obiettivo
{
    public partial class UpdateObiettivo(ProxyObiettivi sdk, ObiettiviStateService stato) : MainClassBase
    {
        [CascadingParameter(Name = "ObiettivoId")] public int ObiettivoId { get; set; }
        private UpdateObiettivoDto? UpdateForm { get; set; }

        public async Task OpenPopup()
        {
            await GetRecord();
        }

        private async Task GetRecord()
        {
            var result = await sdk.SendRequestAsync(a => a.GetObiettivoAsync(ObiettivoId));
            UpdateForm = new UpdateObiettivoDto
            {
                Id = result.Id,
                Categoria = result.Categoria,
                Titolo = result.Titolo,
                Descrizione = result.Descrizione,
                DataCreazione = result.DataCreazione,
                Scadenza = result.Scadenza,
                Completed = result.Completed,
                Target = result.Target,
                CheckMark = result.CheckMark,
                Progressivo = result.Progressivo
            };
            await InvokeAsync(StateHasChanged);
        }

        private async Task Save()
        {
            if (UpdateForm is null) return;

            await sdk.SendRequestAsync(a => a.UpdateObiettivoAsync(UpdateForm));
            await stato.NotificaAggiornamentoAsync();

        }

    }
}
