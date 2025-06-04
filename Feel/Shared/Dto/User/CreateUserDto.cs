using Feel.Shared.Dto.Assistente;
using Feel.Shared.Dto.Tema;
using System.ComponentModel.DataAnnotations;

namespace Feel.Shared.Dto.User
{
    public class CreateUserDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public AssistenteDto? Assistente { get; set; }
        [Required]
        public TemaDto? Tema { get; set; }
    }
}
