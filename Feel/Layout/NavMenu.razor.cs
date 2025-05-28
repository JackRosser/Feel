using Feel.Shared;
using Microsoft.AspNetCore.Components;

namespace Feel.Layout
{
    public partial class NavMenu
    {

        [CascadingParameter] public string? MainTheme { get; set; }

        private List<NavMenuItem>? NavMenuItems { get; set; }

        protected override void OnInitialized()
        {
            NavMenuItems = new List<NavMenuItem>
            {
                new NavMenuItem { Name = "Home", Icon = Icons.Home, Href = "/", Color = $"{MainTheme}-icone" },
                new NavMenuItem { Name = "PersonalArea", Icon = Icons.User, Href = "/personal", Color = $"{MainTheme}-icone" },
                new NavMenuItem { Name = "Settings", Icon = Icons.Settings, Href = "/settings", Color = $"{MainTheme}-icone" },
            };
        }

        private class NavMenuItem
        {
            public string? Name { get; set; }
            public string? Icon { get; set; }
            public string? Color { get; set; }
            public string? Href { get; set; }
        }
    }
}
