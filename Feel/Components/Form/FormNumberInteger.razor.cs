using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Feel.Components.Form;
public partial class FormNumberInteger : FormBase
{
    [Parameter, EditorRequired] public int? Value { get; set; }

    [Parameter] public required Expression<Func<int?>> ValueExpression { get; set; }
    [Parameter] public EventCallback<int?> ValueChanged { get; set; }

}