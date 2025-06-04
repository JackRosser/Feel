using Feel.Shared.Helper;

namespace Feel.Shared.Dto.Assistente
{
    public class AssistenteDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string PicName => NameConverter.NameToPng(Nome);

    }
}
