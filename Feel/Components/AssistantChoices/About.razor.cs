using Feel.Shared.Dto.User;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Feel.Components.AssistantChoices
{
    public partial class About : MainClassBase
    {
        [Parameter, EditorRequired] public int ModalId { get; set; }
        private EditUserDto? UserSettingsEdit { get; set; }


        public void Start()
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

        private async Task Close()
        {
            await JS.InvokeVoidAsync("closeModalById", ModalId);
            await InvokeAsync(StateHasChanged);
        }

    }
}
