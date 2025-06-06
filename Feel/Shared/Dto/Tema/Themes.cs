namespace Feel.Shared.Dto.Tema
{
    public static class Themes
    {
        public static List<TemaDto> ThemesList = new()
        {
            new TemaDto { Id = 1, Nome = "autunno" },
            new TemaDto { Id = 2, Nome = "inverno" },
            new TemaDto { Id = 3, Nome = "primavera" },
            new TemaDto { Id = 4, Nome = "estate" },
        };
    }
}
