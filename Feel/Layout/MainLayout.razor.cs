namespace Feel.Layout
{
    public partial class MainLayout
    {
        public string? MainTheme { get; set; }
        private string? AssistenteNome { get; set; }
        public string Assistente => $"{AssistenteNome}.png";

        protected override void OnInitialized()
        {
            // Qua arriva l'id dal localstorage ed è il tema
            int IdDaLocalStorage = 1;
            MainTheme = IdDaLocalStorage switch
            {
                1 => "caldo",
                2 => "altro",
                _ => "caldo"
            };
            // Qua arriva l'id dall'assistente
            int IdAssistente = 1;
            AssistenteNome = IdAssistente switch
            {
                1 => "giulio",
                2 => "kitty",
                _ => ""
            };
        }

    }
}

