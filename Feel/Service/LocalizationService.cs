using Blazored.LocalStorage;
using System.Globalization;

namespace Feel.Service
{
    public class LocalizationService(ILocalStorageService storage)
    {
        private const string LangKey = "selected-culture";

        public async Task<CultureInfo> GetCurrentCultureAsync()
        {
            var saved = await storage.GetItemAsync<string>(LangKey);
            return string.IsNullOrWhiteSpace(saved) ? new CultureInfo("it") : new CultureInfo(saved);
        }

        public async Task SetCultureAsync(string culture)
        {
            await storage.SetItemAsync(LangKey, culture);
            var newCulture = new CultureInfo(culture);
            CultureInfo.DefaultThreadCurrentCulture = newCulture;
            CultureInfo.DefaultThreadCurrentUICulture = newCulture;
        }
    }
}
