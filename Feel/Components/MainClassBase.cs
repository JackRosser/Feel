using Feel.Service.Proxy;
using Feel.Shared.Dto.Obiettivi;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Feel.Components
{
    public abstract class MainClassBase : ComponentBase, IDisposable
    {
        [CascadingParameter(Name = "MainTheme")] public string? MainTheme { get; set; }
        [Inject] protected ProxyObiettivi proxyObiettivi { get; set; } = default!;
        [Inject] protected IJSRuntime JS { get; set; } = default!;

        protected CancellationTokenSource Ct = new();

        protected FormModel EditModel { get; set; } = new();

        protected IEnumerable<ObiettivoDto>? Obiettivi { get; set; }

        public void Dispose()
        {
            Ct.Cancel();
            Ct.Dispose();
        }

        protected async Task GetAllObiettivi()
        {
            Obiettivi = await proxyObiettivi.SendRequestAsync(a => a.GetAllObiettiviAsync());
        }

        protected override async Task OnInitializedAsync()
        {
            if (Obiettivi is null)
            {
                await GetAllObiettivi();
            }
        }

        public class FormModel
        {
            public CreateObiettivoDto? CreateObiettivoForm { get; set; }

        }
    }
}

