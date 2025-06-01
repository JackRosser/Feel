using Feel.Resources;
using Feel.Shared.Enum;
using Microsoft.Extensions.Localization;

namespace Feel.Shared.Helper
{
    public static class HelperTraduzione
    {
        public static string Traduzione(Category? obj, IStringLocalizer<ResourceLanguage> localizer)
        {
            return obj switch
            {
                Category.Risparmio => localizer[ResourceLanguage.Risparmio],
                Category.Salute => localizer[ResourceLanguage.Salute],
                Category.Alimentazione => localizer[ResourceLanguage.Alimentazione],
                Category.Benessere => localizer[ResourceLanguage.Benessere],
                Category.Bellezza => localizer[ResourceLanguage.Bellezza],
                Category.Moda => localizer[ResourceLanguage.Moda],
                Category.Viaggi => localizer[ResourceLanguage.Viaggi],
                Category.Tecnologia => localizer[ResourceLanguage.Tecnologia],
                Category.Casa => localizer[ResourceLanguage.Casa],
                Category.Auto => localizer[ResourceLanguage.Auto],
                Category.Lavoro => localizer[ResourceLanguage.Lavoro],
                Category.TempoLibero => localizer[ResourceLanguage.TempoLibero],
                Category.Cultura => localizer[ResourceLanguage.Cultura],
                Category.Educazione => localizer[ResourceLanguage.Educazione],
                Category.Famiglia => localizer[ResourceLanguage.Famiglia],
                Category.Animali => localizer[ResourceLanguage.Animali],
                Category.Eventi => localizer[ResourceLanguage.Eventi],
                Category.Sport => localizer[ResourceLanguage.Sport],
                Category.Musica => localizer[ResourceLanguage.Musica],
                Category.Arte => localizer[ResourceLanguage.Arte],
                Category.Natura => localizer[ResourceLanguage.Natura],
                Category.Politica => localizer[ResourceLanguage.Politica],
                Category.Religione => localizer[ResourceLanguage.Religione],
                _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
            };
        }
    }

}
