using Feel.Resources;
using Feel.Shared.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;

namespace Feel.Components
{
    public partial class Modal(IStringLocalizer<ResourceLanguage> Localizer) : MainClassBase
    {
        [Parameter, EditorRequired] public int ModalId { get; set; }
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
                var modalId = ModalType == ModalType.DeleteObietttivo ? $"delete{ModalId}" : $"{ModalId}";
                await JS.InvokeVoidAsync("moveModalToContainer", modalId);
            }
        }

        public async Task Esegui()
        {
            var modalId = ModalType == ModalType.DeleteObietttivo ? $"delete{ModalId}" : $"{ModalId}";

            if (OnActionClick.HasDelegate)
            {
                await OnActionClick.InvokeAsync();
            }

            await JS.InvokeVoidAsync("showModalById", modalId);
        }

        public async Task SimpleOpenPopUp()
        {
            var modalId = ModalType == ModalType.DeleteObietttivo ? $"delete{ModalId}" : $"{ModalId}";
            await JS.InvokeVoidAsync("showModalById", modalId);
        }

        public async Task Elimina()
        {
            var modalId = ModalType == ModalType.DeleteObietttivo ? $"delete{ModalId}" : $"{ModalId}";

            if (OnActionClick.HasDelegate)
            {
                await OnActionClick.InvokeAsync();
            }

            await JS.InvokeVoidAsync("closeModalById", modalId);
        }


    }
}
