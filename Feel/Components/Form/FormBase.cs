using Microsoft.AspNetCore.Components;

namespace Feel.Components.Form
{
    public abstract class FormBase : MainClassBase
    {
        [Parameter, EditorRequired] public string? LabelTitle { get; set; }
        [Parameter] public int Col { get; set; } = 12;
        [Parameter] public int ColMd { get; set; } = 12;
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string? Info { get; set; }
        [Parameter] public string? Placeholder { get; set; }

        protected string ModalId { get; set; } = string.Empty;
        protected string InputId { get; set; } = string.Empty;

        private bool _idGenerated = false;

        private string IdGenerator() => Random.Shared.Next(0, 30072023).ToString();

        protected override void OnParametersSet()
        {
            if (!_idGenerated)
            {
                InputId = IdGenerator();
                ModalId = IdGenerator();
                _idGenerated = true;
            }
        }
    }

}

