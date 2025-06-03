using Feel.Service.Proxy;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Feel.Components.Localization
{
    public partial class LanguageSelector(ProxyLocalization Proxy, NavigationManager Navigation)
    {
        private CultureInfo CurrentCulture = CultureInfo.CurrentUICulture;

        private async Task OnCultureChanged(ChangeEventArgs e)
        {
            var selected = e.Value?.ToString();
            if (!string.IsNullOrWhiteSpace(selected))
            {
                await Proxy.SendRequestAsync(s => s.SetCultureAsync(selected));
                Navigation.NavigateTo(Navigation.Uri, forceLoad: true);
            }
        }
    }
}

// Procedure aggiunta lingua

/*

Prima la aggiungo in Resources

Resources /
└── ResourceLanguage.resx         ← fallback
└── ResourceLanguage.it.resx     ← italiano
└── ResourceLanguage.en.resx     ← inglese
└── ResourceLanguage.de.resx     ← tedesco ✅

Poi nel selettore in .razor

<select class="form-select" @onchange="OnCultureChanged" value="@CurrentCulture.Name">
    <option value="it">🇮🇹 Italiano</option>
    <option value="en">🇬🇧 English</option>
    <option value="de">🇩🇪 Deutsch</option> @* Aggiunto tedesco *@
</select>

*/