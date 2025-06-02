using Feel.Service.Proxy;
using Feel.Shared.Dto.User;

namespace Feel.Layout
{
    public partial class MainLayout(ProxyUser userSdk)
    {
        public string? MainTheme { get; set; }
        private string? AssistenteNome { get; set; }
        public string Assistente => $"{AssistenteNome}.png";
        private UserDto? User { get; set; }
        protected override async Task OnInitializedAsync()
        {
            // Qua arriva l'id dal localstorage ed è il tema
            int IdDaLocalStorage = 1;
            MainTheme = IdDaLocalStorage switch
            {
                1 => "autunno",
                2 => "altro",
                _ => "autunno"
            };
            // Qua arriva l'id dall'assistente
            int IdAssistente = 2;
            AssistenteNome = IdAssistente switch
            {
                1 => "giulio",
                2 => "kitty",
                _ => ""
            };
            // Qua arriva il nome utente
            User = await userSdk.SendRequestAsync(a => a.GetUser());
            if (User is null)
            {
                User = new UserDto
                {
                    Id = 0,
                    Name = "UserTest",
                };
            }
            StateHasChanged();
        }

    }
}

