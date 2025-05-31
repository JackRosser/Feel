using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Feel.Components.Form;
public partial class FormText : MainClassBase
{
    [Parameter, EditorRequired] public string? Value { get; set; }

    [Parameter] public required Expression<Func<string?>> ValueExpression { get; set; }
    [Parameter] public EventCallback<string?> ValueChanged { get; set; }
    [Parameter, EditorRequired] public string? LabelTitle { get; set; }
    [Parameter] public string? Placeholder { get; set; }

}