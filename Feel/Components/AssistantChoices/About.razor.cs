using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Feel.Components.AssistantChoices
{
    public partial class About : MainClassBase
    {
        [Parameter, EditorRequired] public int ModalId { get; set; }



        public void Start()
        {

            StateHasChanged();
        }


        private async Task Close()
        {

            await JS.InvokeVoidAsync("closeModalById", ModalId);
            await InvokeAsync(StateHasChanged);
        }
    }
}
