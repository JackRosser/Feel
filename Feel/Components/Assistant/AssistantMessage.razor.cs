﻿using Feel.Components.AssistantChoices;
using Feel.Resources;
using Feel.Shared.Enum;
using Microsoft.AspNetCore.Components;

namespace Feel.Components.Assistant
{
    public partial class AssistantMessage
    {
        [CascadingParameter(Name = "MainTheme")] public string? MainTheme { get; set; }
        [Parameter] public EventCallback OnActionClick { get; set; }
        [Parameter, EditorRequired] public int ModalId { get; set; }
        [Parameter] public string? CssClass { get; set; }
        [Parameter] public EventCallback SitAssistant { get; set; }
        [Parameter, EditorRequired] public ModalType AssistantChoice { get; set; }
        private AddObiettivo? _addObiettivo;
        private ChangeTheme? _changeTheme;
        private UserSettings? _userSettings;
        private About? _about;
        private void Action()
        {
            SitAssistant.InvokeAsync();
            switch (AssistantChoice)
            {
                case ModalType.AggiungiObiettivo:
                    _addObiettivo?.StartForm();
                    break;
                case ModalType.CambiaTema:
                    _changeTheme?.StartForm();
                    break;
                case ModalType.AreaUtente:
                    _userSettings?.StartForm();
                    break;
                case ModalType.InformazioniApp:
                    _about?.Start();
                    break;
                default:
                    break;
            }
        }
        private string ActionClass => AssistantChoice switch
        {
            ModalType.AggiungiObiettivo => "aggiungi-obiettivo",
            ModalType.CambiaTema => "cambia-tema",
            ModalType.AreaUtente => "area-utente",
            ModalType.InformazioniApp => "about",
            _ => string.Empty
        };
        private string ActionText => AssistantChoice switch
        {
            ModalType.AggiungiObiettivo => Localizer[ResourceLanguage.MessaggioAssistenteAggiuntaObiettivo],
            ModalType.CambiaTema => Localizer[ResourceLanguage.MessaggioAssistenteCambiaTema],
            ModalType.AreaUtente => Localizer[ResourceLanguage.MessaggioAssistenteAreaUtente],
            ModalType.InformazioniApp => Localizer[ResourceLanguage.MessaggioAssistenteAbout],
            _ => string.Empty
        };


    }
}
