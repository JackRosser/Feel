using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Feel.Components.Form;
public partial class FormText : FormBase
{
    [Parameter, EditorRequired] public string? Value { get; set; }

    [Parameter] public required Expression<Func<string?>> ValueExpression { get; set; }
    [Parameter] public EventCallback<string?> ValueChanged { get; set; }

}