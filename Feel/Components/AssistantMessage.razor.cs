using Feel.Resources;
using Feel.Shared.Enum;
using Microsoft.AspNetCore.Components;

namespace Feel.Components
{
    public partial class AssistantMessage
    {
        [CascadingParameter(Name = "MainTheme")] public string? MainTheme { get; set; }
        [Parameter, EditorRequired] public AssistantMessageEnum Action { get; set; }
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

        private void OnActionClick()
        {
            switch (Action)
            {
                case AssistantMessageEnum.AggiungiObiettivo:
                    OnAddGoal();
                    break;

                case AssistantMessageEnum.CambiaTema:
                    OnChangeTheme();
                    break;

                case AssistantMessageEnum.AreaUtente:
                    OnUserArea();
                    break;

                case AssistantMessageEnum.About:
                    OnAbout();
                    break;

                default:
                    break;
            }
        }


        private void OnAddGoal()
        {
            Console.WriteLine("Aggiungi Obiettivo Clicked");
        }

        private void OnChangeTheme()
        {
            Console.WriteLine("Cambia Tema Clicked");
        }

        private void OnUserArea()
        {
            Console.WriteLine("Area Utente Clicked");
        }

        private void OnAbout()
        {
            Console.WriteLine("About Clicked");
        }
    }
}
