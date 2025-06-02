using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Feel.Components.Form;
public partial class FormRadio : FormBase
{
    [Parameter, EditorRequired] public bool Value { get; set; }

    [Parameter] public required Expression<Func<bool>> ValueExpression { get; set; }
    [Parameter] public EventCallback<bool> ValueChanged { get; set; }

}