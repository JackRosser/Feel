namespace Feel.Shared.Helper
{
    public static class NameConverter
    {
        public static string NameToPng(string? name)
        {
            return $"{name}.png";
        }

        public static string NameToCapitalize(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return char.ToUpper(input[0]) + input[1..];
        }


    }
}
