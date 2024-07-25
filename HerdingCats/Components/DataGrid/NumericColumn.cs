using Microsoft.AspNetCore.Components;

using Radzen.Blazor;

namespace HerdingCats.Components.DataGrid;

public class NumericColumn<TItem, TValue> : ColumnBase<TItem, TValue> where TValue : struct
{
    protected override RenderFragment<TItem> GetEditTemplate() => item => builder =>
    {
        builder.OpenComponent<RadzenNumeric<TValue>>(0);
        builder.AddAttribute(1, "Value", getter!.Invoke(item));
        builder.AddAttribute(2, "ValueChanged", new EventCallback<TValue>(this, (TValue val) => setter!.Invoke(item, val)));
        builder.CloseComponent();
    };
}