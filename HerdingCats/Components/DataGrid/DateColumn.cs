using Microsoft.AspNetCore.Components;

using Radzen.Blazor;

namespace HerdingCats.Components.DataGrid;

public class DateColumn<TItem> : ColumnBase<TItem, DateTime> 
{
    protected override RenderFragment<TItem> GetEditTemplate() => item => builder =>
    {
        builder.OpenComponent<RadzenDatePicker<DateTime>>(0);
        builder.AddAttribute(1, "Value", getter!.Invoke(item));
        builder.AddAttribute(2, "ValueChanged", new EventCallback<DateTime>(this, (DateTime val) => setter!.Invoke(item, val)));
        builder.CloseComponent();
    };
}