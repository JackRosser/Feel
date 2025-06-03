using Feel.Shared.Dto.Assistente;
using Feel.Shared.Dto.Tema;

namespace Feel.Shared.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public AssistenteDto? Assistente { get; set; }
        public TemaDto? Tema { get; set; }
    }
}
