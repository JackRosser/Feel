using Feel.Resources;
using Feel.Service.ChangeStateHelper;
using Feel.Service.Proxy;
using Feel.Shared.Dto.Obiettivi;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace Feel.Components.Obiettivo
{
    public partial class UpdateObiettivo(ProxyObiettivi sdk, ObiettiviStateService stato) : MainClassBase
    {
        [CascadingParameter(Name = "ObiettivoId")] public int ObiettivoId { get; set; }
        private EditObiettivo? EditModel { get; set; }
        private ObiettivoDto? Obiettivo { get; set; }
        public async Task OpenPopup()
        {
            await GetRecord();
        }

        private async Task GetRecord()
        {
            var result = await sdk.SendRequestAsync(a => a.GetObiettivoAsync(ObiettivoId));
            Obiettivo = result;
            EditModel = new();
            await InvokeAsync(StateHasChanged);
        }

        private async Task Save()
        {
            if (Obiettivo is null) return;
            else if (EditModel is null) return;

            Obiettivo.Progressivo = Sum(Obiettivo.Progressivo, EditModel.Importo.Value);
            await sdk.SendRequestAsync(a => a.UpdateObiettivoAsync(Obiettivo));
            await stato.NotificaAggiornamentoAsync();

        }

        public class EditObiettivo
        {
            [Required(ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "InserisciValore")]
            public int? Importo { get; set; }
        }

        private int Sum(int target, int progressive)
        {
            return target + progressive;
        }

    }
}
