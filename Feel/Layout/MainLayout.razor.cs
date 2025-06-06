using Feel.Service.ChangeStateHelper;
using Feel.Service.Proxy;
using Feel.Shared.Dto.User;

namespace Feel.Layout
{
    public partial class MainLayout(ProxyUser userSdk, UserStateService Stato)
    {
        private UserDto? User { get; set; }
        private string Theme => User?.Tema?.Nome ?? "initial";
        protected override async Task OnInitializedAsync()
        {
            Stato.TemaUtenteAggiornato += OnTemaAggiornato;
            User = await userSdk.SendRequestAsync(a => a.GetUser());
            StateHasChanged();
        }

        private async Task OnTemaAggiornato()
        {
            User = await userSdk.SendRequestAsync(a => a.GetUser());
            await InvokeAsync(StateHasChanged);
        }

    }
}

