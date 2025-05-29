using Feel.Shared.Enum;

namespace Feel.Shared.Dto.Obiettivi
{
    public class ObiettivoDto
    {
        public int Id { get; set; }
        public Category Categoria { get; set; }
        public string? Titolo { get; set; }
        public string? Descrizione { get; set; }
        public DateOnly Scadenza { get; set; }
    }
}
