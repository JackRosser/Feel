using Feel.Service.Proxy;
using Feel.Shared.Helper;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Feel.Components.Localization
{
    public partial class LanguageSelector(ProxyLocalization Proxy, NavigationManager Navigation)
    {
        private CultureInfo CurrentCulture = CultureInfo.CurrentUICulture;

        private List<LanguageOption> Languages = new()
        {
            new LanguageOption { Value = "it" },
            new LanguageOption { Value = "en" }
        };

        private async Task ChangeCulture(string culture)
        {
            if (!string.IsNullOrWhiteSpace(culture) && culture != CurrentCulture.Name)
            {
                await Proxy.SendRequestAsync(s => s.SetCultureAsync(culture));
                Navigation.NavigateTo(Navigation.Uri, forceLoad: true);
            }

        }

        private class LanguageOption
        {
            public string? Value { get; set; }
            public string PicName => NameConverter.NameToPng(Value);
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