using Feel.Service.ChangeStateHelper;
using Feel.Service.Proxy;
using Feel.Shared.Dto.Tema;
using Feel.Shared.Dto.User;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Feel.Components.AssistantChoices
{
    public partial class ChangeTheme(ProxyUser sdk, UserStateService stato) : MainClassBase
    {
        [Parameter, EditorRequired] public int ModalId { get; set; }

        private UserDto? UserClassEdit { get; set; }
        private DotNetObjectReference<ChangeTheme>? _dotNetRef;


        [JSInvokable]
        public async Task AggiornaTemaDaIndice(int index)
        {
            if (index < 0 || index >= Themes.ThemesList.Count) return;

            var tema = Themes.ThemesList[index];
            await Save(tema);
        }


        public async void StartForm()
        {
            UserClassEdit = User;
            StateHasChanged();

            await Task.Delay(100);

            _dotNetRef ??= DotNetObjectReference.Create(this);
            await JS.InvokeVoidAsync("ThemeCarouselInterop.startListening", _dotNetRef);
        }


        private async Task Save(TemaDto tema)
        {
            if (UserClassEdit is null)
            {
                return;
            }

            UserClassEdit.Tema = tema;
            await sdk.SendRequestAsync(a => a.UpdateUserAsync(UserClassEdit));
            await stato.NotificaCambioTemaAsync();
            await InvokeAsync(StateHasChanged);
        }


        private async Task Close()
        {
            if (UserClassEdit is null) return;
            await JS.InvokeVoidAsync("closeModalById", ModalId);
            UserClassEdit = null; // Reset the form
            await InvokeAsync(StateHasChanged);
        }

    }
}
