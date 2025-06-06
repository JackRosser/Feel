using Feel.Resources;
using Feel.Shared.Dto.Assistente;
using Feel.Shared.Dto.Tema;
using System.ComponentModel.DataAnnotations;

namespace Feel.Shared.Dto.User
{
    public class EditUserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "InserisciNome")]
        public string? Name { get; set; }

        public AssistenteDto? Assistente { get; set; }
        public TemaDto? Tema { get; set; }
    }
}
