namespace Feel.Layout
{
    public partial class MainLayout
    {
        public string? MainTheme { get; set; }

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
        }

    }
}

