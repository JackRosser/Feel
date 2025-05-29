using Feel.Resources;
using Feel.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace Feel.Shared.Dto.Obiettivi
{
    public class CreateObiettivoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "InserisciCategoria")]
        public Category Categoria { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "InserisciTitolo")]
        [StringLength(20, ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "MassimoVentiCaratteri")]
        public string? Titolo { get; set; }
        public string? Descrizione { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "InserisciData")]
        public DateOnly? Scadenza { get; set; }
    }
}
