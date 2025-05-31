using Feel.Resources;
using Feel.Shared.Enum;
using Microsoft.AspNetCore.Components;

namespace Feel.Components.Assistant
{
    public partial class AssistantMessage
    {
        [CascadingParameter(Name = "MainTheme")] public string? MainTheme { get; set; }
        [Parameter, EditorRequired] public AssistantMessageEnum Action { get; set; }
        [Parameter, EditorRequired] public EventCallback OnActionClick { get; set; }
        [Parameter] public string? CssClass { get; set; }
        private string ActionClass => Action switch
        {
            AssistantMessageEnum.AggiungiObiettivo => "aggiungi-obiettivo",
            AssistantMessageEnum.CambiaTema => "cambia-tema",
            AssistantMessageEnum.AreaUtente => "area-utente",
            AssistantMessageEnum.About => "about",
            _ => string.Empty
        };
        private string ActionText => Action switch
        {
            AssistantMessageEnum.AggiungiObiettivo => Localizer[ResourceLanguage.MessaggioAssistenteAggiuntaObiettivo],
            AssistantMessageEnum.CambiaTema => Localizer[ResourceLanguage.MessaggioAssistenteCambiaTema],
            AssistantMessageEnum.AreaUtente => Localizer[ResourceLanguage.MessaggioAssistenteAreaUtente],
            AssistantMessageEnum.About => Localizer[ResourceLanguage.MessaggioAssistenteAbout],
            _ => string.Empty
        };


    }
}
