using Feel.Service.Proxy;
using Feel.Shared.Dto.Assistente;
using Feel.Shared.Dto.Tema;
using Feel.Shared.Dto.User;

namespace Feel.Layout
{
    public partial class MainLayout(ProxyUser userSdk)
    {
        private UserDto? User { get; set; }
        protected override async Task OnInitializedAsync()
        {
            User = await userSdk.SendRequestAsync(a => a.GetUser());
            if (User is null)
            {
                User = new UserDto
                {
                    Id = 0,
                    Name = "UserTest",
                    Assistente = new AssistenteDto
                    {
                        Id = 1,
                        Nome = "giulio"
                    },
                    Tema = new TemaDto
                    {
                        Id = 1,
                        Nome = "autunno"
                    }
                };
            }
            StateHasChanged();
        }

    }
}

