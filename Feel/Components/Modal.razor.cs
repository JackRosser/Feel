using Feel.Resources;
using Feel.Shared.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;

namespace Feel.Components
{
    public partial class Modal(IStringLocalizer<ResourceLanguage> Localizer) : MainClassBase
    {
        [CascadingParameter(Name = "ModalId")] public string? ModalId { get; set; }

        [Parameter] public string? Title { get; set; }
        [Parameter, EditorRequired] public ModalType ModalType { get; set; }
        [Parameter] public bool IsSubmit { get; set; } = false;
        [Parameter] public string? SubmitText { get; set; } = Localizer[ResourceLanguage.Ok];
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string? ActionClass { get; set; }
        [Parameter] public string? CssClass { get; set; }
        [Parameter] public string? ActionText { get; set; }
        /// <summary>
        /// Da usare solo per istanziare qualcosa all'apertura di un form, metterlo su un div che contiene il toggle per aprire il modale
        /// </summary>
        [Parameter] public EventCallback OnActionClick { get; set; }

        private string? TypeButton { get; set; }

        protected override void OnParametersSet()
        {
            TypeButton = IsSubmit ? "submit" : "button";

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JS.InvokeVoidAsync("moveModalToContainer", ModalId);
            }
        }



    }
}
