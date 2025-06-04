using Feel.Shared.Enum;
using Feel.Shared.Helper;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Feel.Components.Form;

/// <summary>
/// Componente generico per la selezione di un enum. Supporta anche gli enum nullable con TEnum?.
/// </summary>
/// <typeparam name="TEnum">Tipo di Enum</typeparam>
public partial class EnumSelector<TEnum> : FormBase
{
    [Parameter, EditorRequired] public TEnum? Value { get; set; }

    [Parameter] public required Expression<Func<TEnum?>> ValueExpression { get; set; }
    [Parameter] public EventCallback<TEnum?> ValueChanged { get; set; }
    /// <summary>
    /// Imposta se mostrare l'opzione di default che equivale a non aver fatto alcuna scelta.
    /// </summary>
    [Parameter]
    public bool ShowDefaultOption { get; set; } = true;

    /// <summary>
    /// Testo per l'opzione di default se diverso da quello predefinito: "Seleziona un valore...".'
    /// </summary>
    [Parameter]
    public string? DefaultOptionText { get; set; }

    private IEnumerable<TEnum> EnumValues => Enum.GetValues(UnderlyingType).Cast<TEnum>();

    private static Type UnderlyingType => Nullable.GetUnderlyingType(typeof(TEnum)) ?? typeof(TEnum);

    private string GetLabel<T>(T value)
    {
        if (typeof(T) == typeof(Category))
            return HelperTraduzione.Traduzione((Category)(object)value, Localizer);

        return value?.ToString() ?? "";
    }


}