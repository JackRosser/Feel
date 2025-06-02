using Feel.Shared.Enum;

namespace Feel.Shared.Dto.Obiettivi
{
    public class ObiettivoDto
    {
        public int Id { get; set; }
        public Category? Categoria { get; set; }
        public string? Titolo { get; set; } = null!;
        public string? Descrizione { get; set; }
        public DateOnly DataCreazione { get; set; }
        public DateOnly? Scadenza { get; set; }
        public DateOnly? DataCompletamento { get; set; }
        public bool Completed { get; set; }
        public int? Target { get; set; }
        public bool CheckMark { get; set; }
        public int Progressivo { get; set; } = 0;
        public int Percentage => (Target.HasValue && Target.Value > 0) ? Math.Min(100, Progressivo * 100 / Target.Value) : 0;
    }
}