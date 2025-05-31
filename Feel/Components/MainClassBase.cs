using Feel.Shared.Dto.Obiettivi;
using Microsoft.AspNetCore.Components;

namespace Feel.Components
{
    public abstract class MainClassBase : ComponentBase, IDisposable
    {
        [CascadingParameter(Name = "MainTheme")] public string? MainTheme { get; set; }


        protected CancellationTokenSource Ct = new();

        protected FormModel EditModel { get; set; } = new();

        public void Dispose()
        {
            Ct.Cancel();
            Ct.Dispose();
        }

        public class FormModel
        {
            public CreateObiettivoDto? CreateObiettivoForm { get; set; }

        }
    }
}

