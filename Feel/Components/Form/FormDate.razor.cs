using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Feel.Components.Form;
public partial class FormDate : FormBase
{
    [Parameter, EditorRequired] public DateOnly? Value { get; set; }

    [Parameter] public required Expression<Func<DateOnly?>> ValueExpression { get; set; }
    [Parameter] public EventCallback<DateOnly?> ValueChanged { get; set; }

}