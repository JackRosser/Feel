using Feel.Resources;
using Feel.Shared.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Feel.Components
{
    public partial class Modal(IStringLocalizer<ResourceLanguage> Localizer)
    {
        [CascadingParameter(Name = "ModalId")] public string? ModalId { get; set; }
        [CascadingParameter(Name = "MainTheme")] public string? MainTheme { get; set; }
        [Parameter] public string? Title { get; set; }
        [Parameter] public ModalType ModalType { get; set; } = ModalType.Button;
        [Parameter] public bool IsSubmit { get; set; } = false;
        [Parameter] public string? SubmitText { get; set; } = Localizer[ResourceLanguage.Ok];
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string? ActionClass { get; set; }
        [Parameter] public string? CssClass { get; set; }
        [Parameter] public string? ActionText { get; set; }

        private string? TypeButton { get; set; }

        protected override void OnParametersSet()
        {
            TypeButton = IsSubmit ? "submit" : "button";

        }




    }
}
