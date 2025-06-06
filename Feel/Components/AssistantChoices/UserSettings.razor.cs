using Feel.Service.ChangeStateHelper;
using Feel.Service.Proxy;
using Feel.Shared.Dto.Assistente;
using Feel.Shared.Dto.User;
using Feel.Shared.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Feel.Components.AssistantChoices
{
    public partial class UserSettings(ProxyUser sdk, UserStateService stato) : MainClassBase
    {
        [Parameter, EditorRequired] public int ModalId { get; set; }

        private EditUserDto? UserSettingsEdit { get; set; }



        public void StartForm()
        {
            if (User is null)
            {
                return;
            }
            UserSettingsEdit = new()
            {
                Id = User.Id,
                Name = User.Name,
                Assistente = User.Assistente,
                Tema = User.Tema
            };
            StateHasChanged();
        }

        private void AssistantSelected(AssistenteDto assistente)
        {
            if (UserSettingsEdit is null)
            {
                return;
            }
            UserSettingsEdit.Assistente = assistente;
        }


        private async Task Save()
        {
            if (UserSettingsEdit is null)
            {
                return;
            }

            await sdk.SendRequestAsync(a => a.UpdateUserAsync(new UserDto
            {
                Id = UserSettingsEdit.Id,
                Name = NameConverter.NameToCapitalize(UserSettingsEdit.Name),
                Assistente = UserSettingsEdit.Assistente,
                Tema = UserSettingsEdit.Tema
            }));
            await stato.NotificaCambioTemaAsync();
            await JS.InvokeVoidAsync("closeModalById", ModalId);
            await InvokeAsync(StateHasChanged);
        }


        private async Task Close()
        {
            if (UserSettingsEdit is null) return;
            await JS.InvokeVoidAsync("closeModalById", ModalId);
            await InvokeAsync(StateHasChanged);
        }
    }
}
