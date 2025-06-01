using Feel.Resources;
using Feel.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace Feel.Shared.Dto.Obiettivi
{
    public class CreateObiettivoDto
    {
        [Required(ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "InserisciCategoria")]
        public Category? Categoria { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "InserisciTitolo")]
        [StringLength(20, ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "MassimoVentiCaratteri")]
        public string? Titolo { get; set; }
        public string? Descrizione { get; set; }
        public DateOnly DataCreazione { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "InserisciData")]
        public DateOnly? Scadenza { get; set; }
        public bool Completed { get; set; } = false;
        [Required(ErrorMessageResourceType = typeof(ResourceLanguage), ErrorMessageResourceName = "InserisciTarget")]
        public int? Target { get; set; }
        public bool CheckMark { get; set; } = false;
    }
}
