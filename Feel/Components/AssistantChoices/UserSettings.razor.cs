using Feel.Service.ChangeStateHelper;
using Feel.Service.Proxy;
using Feel.Shared.Dto.Tema;
using Feel.Shared.Dto.User;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Feel.Components.AssistantChoices
{
    public partial class UserSettings(ProxyUser sdk, UserStateService stato) : MainClassBase
    {
        [Parameter, EditorRequired] public int ModalId { get; set; }

        private UserDto? UserSettingsEdit { get; set; }



        public void StartForm()
        {
            UserSettingsEdit = User;
            StateHasChanged();
        }


        private async Task Save(TemaDto tema)
        {
            if (UserSettingsEdit is null)
            {
                return;
            }

            await sdk.SendRequestAsync(a => a.UpdateUserAsync(UserSettingsEdit));
            await stato.NotificaCambioTemaAsync();
            await InvokeAsync(StateHasChanged);
        }


        private async Task Close()
        {
            if (UserSettingsEdit is null) return;
            await JS.InvokeVoidAsync("closeModalById", ModalId);
            UserSettingsEdit = null; // Reset the form
            await InvokeAsync(StateHasChanged);
        }
    }
}
