using Feel.Service.Proxy;
using Feel.Shared.Dto.Assistente;
using Feel.Shared.Dto.Tema;
using Feel.Shared.Dto.User;
using Microsoft.AspNetCore.Components;

namespace Feel.Components
{
    public partial class Setup(ProxyUser sdk)
    {
        private CreateUserDto? CreateUserModel { get; set; }
        private List<AssistenteDto> Assistenti { get; set; } = new()
        {
            new AssistenteDto { Id = 1, Nome = "giulio" },
            new AssistenteDto { Id = 2, Nome = "kitty" },
        };
        private List<TemaDto> Themes { get; set; } = new()
        {
            new TemaDto { Id = 1, Nome = "autunno" },
            new TemaDto { Id = 2, Nome = "inverno" },
            new TemaDto { Id = 3, Nome = "primavera" },
            new TemaDto { Id = 4, Nome = "estate" },
        };
        // Scelta nome
        private bool PageOne { get; set; } = true;
        // Scelta assistente
        private bool PageTwo { get; set; } = false;
        // Scelta tema
        private bool PageThree { get; set; } = false;
        // recap e conferma
        private bool PageFour { get; set; } = false;
        private bool PageFive { get; set; } = false;
        private int? AssistantId { get; set; }
        private bool IsNameValid => !string.IsNullOrWhiteSpace(CreateUserModel?.Name);

        private void OnNameInput(ChangeEventArgs e)
        {
            if (CreateUserModel is not null)
            {
                CreateUserModel.Name = e.Value?.ToString();
            }
        }

        public static string PrimaMaiuscola(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }


        private void Indietro()
        {
            if (PageTwo)
            {
                PageTwo = false;
                PageOne = true;
            }
            else if (PageThree)
            {
                PageThree = false;
                PageTwo = true;
            }
            else if (PageFour)
            {
                PageFour = false;
                PageThree = true;
            }

            else if (PageFive)
            {
                PageFive = false;
                PageFour = true;
            }
        }

        private void Avanti()
        {
            if (PageOne)
            {
                PageOne = false;
                PageTwo = true;
            }
            else if (PageTwo)
            {
                PageTwo = false;
                PageThree = true;
            }
            else if (PageThree)
            {
                PageThree = false;
                PageFour = true;
            }

            else if (PageFour)
            {
                PageFour = false;
                PageFive = true;
            }
        }


        private void SelectAssistente(AssistenteDto assistente)
        {
            if (CreateUserModel is null)
            {
                return;
            }
            CreateUserModel.Assistente = assistente;
        }

        private void SelectTema(TemaDto tema)
        {
            if (CreateUserModel is null)
            {
                return;
            }
            CreateUserModel.Tema = tema;
        }

        private async Task Salva()
        {
            if (CreateUserModel is null) return;
            await sdk.SendRequestAsync(a => a.CreateNewUserAsync(new UserDto
            {
                Name = CreateUserModel.Name,
                Assistente = CreateUserModel.Assistente,
                Tema = CreateUserModel.Tema
            }));
            NavManager.NavigateTo("/");
        }

        protected override void OnInitialized()
        {
            CreateUserModel = new();

        }


    }


}
