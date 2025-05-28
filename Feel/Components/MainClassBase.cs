using Microsoft.AspNetCore.Components;

namespace Feel.Components
{
    public abstract class MainClassBase : ComponentBase, IDisposable
    {

        protected CancellationTokenSource Ct = new();

        public void Dispose()
        {
            Ct.Cancel();
            Ct.Dispose();
        }



    }
}

