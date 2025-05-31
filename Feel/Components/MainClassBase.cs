using Microsoft.AspNetCore.Components;

namespace Feel.Components
{
    public abstract class MainClassBase : ComponentBase, IDisposable
    {
        [CascadingParameter(Name = "MainTheme")] public string? MainTheme { get; set; }

        protected CancellationTokenSource Ct = new();

        public void Dispose()
        {
            Ct.Cancel();
            Ct.Dispose();
        }



    }
}

