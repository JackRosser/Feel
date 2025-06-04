using Feel.Resources;
using Feel.Shared.Dto.Obiettivi;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using static Feel.Components.Obiettivo.UpdateObiettivo;

namespace Feel.Components.Form
{
    public partial class FormLayout(IStringLocalizer<ResourceLanguage> Localizer) : MainClassBase
    {
        [CascadingParameter(Name = "ModalId")] public string? ModalId { get; set; }
        [Parameter, EditorRequired] public EventCallback OnSubmit { get; set; }
        [Parameter] public CreateObiettivoDto? CreateModel { get; set; }
        [Parameter] public EditObiettivoValore? UpdateModelValore { get; set; }
        [Parameter] public EditObiettivoCheck? UpdateModelCheck { get; set; }
        [Parameter] public bool UpdateModelCheckValidation { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string SubmitText { get; set; } = Localizer[ResourceLanguage.Salva];
        [Parameter] public string CloseText { get; set; } = Localizer[ResourceLanguage.Annulla];
        private bool IsLoaded { get; set; } = false;

        private async Task HandleValidSubmit()
        {
            await JS.InvokeVoidAsync("closeModalById", ModalId);
            await OnSubmit.InvokeAsync();
        }


        protected override void OnParametersSet()
        {
            IsLoaded = true;
            InvokeAsync(StateHasChanged);
        }
    }
}
