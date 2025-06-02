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
                1 => "autunno",
                2 => "altro",
                _ => "autunno"
            };
            // Qua arriva l'id dall'assistente
            int IdAssistente = 2;
            AssistenteNome = IdAssistente switch
            {
                1 => "giulio",
                2 => "kitty",
                _ => ""
            };
        }

    }
}

