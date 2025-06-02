using Feel.Shared.Dto.User;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Feel.Components
{
    public abstract class MainClassBase : ComponentBase, IDisposable
    {
        [CascadingParameter(Name = "MainTheme")] public string? MainTheme { get; set; }
        [CascadingParameter(Name = "Assistente")] public string? AssistenteNome { get; set; }
        [CascadingParameter(Name = "User")] public UserDto User { get; set; }
        [Inject] protected IJSRuntime JS { get; set; } = default!;

        protected CancellationTokenSource Ct = new();

        // ✳️ Metodo virtuale chiamato alla fine di Dispose()
        protected virtual void OnDispose() { }

        public void Dispose()
        {
            Ct.Cancel();
            Ct.Dispose();
            OnDispose(); // consente ai figli di fare cleanup
        }
    }

}

