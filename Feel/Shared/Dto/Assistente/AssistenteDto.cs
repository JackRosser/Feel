namespace Feel.Shared.Dto.Assistente
{
    public class AssistenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string PicName => NameToPng(Nome);
        private string NameToPng(string name)
        {
            return $"{name}.png";
        }
    }
}
