using Feel.Resources;
using Feel.Service.ChangeStateHelper;
using Feel.Service.Proxy;
using Feel.Shared.Dto.Obiettivi;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;

namespace Feel.Components.Obiettivo
{
    public partial class UpdateObiettivo(ProxyObiettivi sdk, ObiettiviStateService stato) : MainClassBase
    {
        [Parameter, EditorRequired] public int ObiettivoId { get; set; }
        private EditObiettivoValore? EditModelValore { get; set; }
        private EditObiettivoCheck? EditModelCheck { get; set; }
        private ObiettivoDto? Obiettivo { get; set; }
        public async Task OpenPopup()
        {
            await GetRecord();
        }

        private async Task GetRecord()
        {
            var result = await sdk.SendRequestAsync(a => a.GetObiettivoAsync(ObiettivoId));
            Obiettivo = result;
            if (Obiettivo is not null && Obiettivo.CheckMark)
            {
                EditModelCheck = new();
            }
            else if (Obiettivo is not null && !Obiettivo.CheckMark)
            {
                EditModelValore = new();
            }
            await InvokeAsync(StateHasChanged);
        }

        private async Task SaveValore()
        {
            if (Obiettivo is null) return;
            else if (EditModelValore is null) return;

            Obiettivo.Progressivo = Sum(Obiettivo.Progressivo, EditModelValore.Importo.Value);
            await sdk.SendRequestAsync(a => a.UpdateObiettivoAsync(Obiettivo));
            await JS.InvokeVoidAsync("closeModalById", ObiettivoId);
            await stato.NotificaAggiornamentoAsync();

        }

        private async Task SaveCheck()
        {
            if (Obiettivo is null) return;
            else if (EditModelCheck is null) return;

            Obiettivo.Progressivo = Sum(Obiettivo.Progressivo, 1);
            await sdk.SendRequestAsync(a => a.UpdateObiettivoAsync(Obiettivo));
            await JS.InvokeVoidAsync("closeModalById", ObiettivoId);
            await stato.NotificaAggiornamentoAsync();

        }

        public class EditObiettivoValore
        {
            [Required(ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "InserisciValore")]
            public int? Importo { get; set; }
        }

        public class EditObiettivoCheck
        {
            [Required(ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "SpuntaCasella")]
            public bool Check { get; set; }
        }

        private int Sum(int progressivo, int aggiunta)
        {
            return progressivo + aggiunta;
        }

    }
}
