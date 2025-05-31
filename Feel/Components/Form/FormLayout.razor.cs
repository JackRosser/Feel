using Feel.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Feel.Components.Form
{
    public partial class FormLayout(IStringLocalizer<ResourceLanguage> Localizer) : MainClassBase
    {
        [Parameter, EditorRequired] public EventCallback OnSubmit { get; set; }
        [Parameter, EditorRequired] public FormModel? Model { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string SubmitText { get; set; } = Localizer[ResourceLanguage.Salva];
        [Parameter] public string CloseText { get; set; } = Localizer[ResourceLanguage.Annulla];
        private bool IsLoaded { get; set; } = false;

        protected override void OnParametersSet()
        {
            IsLoaded = true;
            InvokeAsync(StateHasChanged);
        }
    }
}
