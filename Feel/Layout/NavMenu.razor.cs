using Feel.Shared;
using Microsoft.AspNetCore.Components;

namespace Feel.Layout
{
    public partial class NavMenu
    {

        [Parameter] public string? NavMenuColor { get; set; }

        private List<NavMenuItem>? NavMenuItems { get; set; }

        protected override void OnParametersSet()
        {
            NavMenuItems = new List<NavMenuItem>
            {
                new NavMenuItem { Name = "Home", Icon = Icons.Home, Href = "/", Color = $"{NavMenuColor}-icone" },
                new NavMenuItem { Name = "PersonalArea", Icon = Icons.User, Href = "/personal", Color = $"{NavMenuColor}-icone" },
                new NavMenuItem { Name = "Settings", Icon = Icons.Settings, Href = "/settings", Color = $"{NavMenuColor}-icone" },
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
