using Feel.Service.Proxy;
using Feel.Shared.Dto.User;

namespace Feel.Layout
{
    public partial class MainLayout(ProxyUser userSdk)
    {
        private UserDto? User { get; set; }
        private string Theme => User?.Tema?.Nome ?? "initial";
        protected override async Task OnInitializedAsync()
        {
            User = await userSdk.SendRequestAsync(a => a.GetUser());
            StateHasChanged();
        }

    }
}

