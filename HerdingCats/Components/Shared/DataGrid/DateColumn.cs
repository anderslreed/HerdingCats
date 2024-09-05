using HerdingCats.Components.Shared.DataGrid;

using Microsoft.AspNetCore.Components;

using Radzen.Blazor;

namespace HerdingCats.Components.Shared.DataGrid;

public class DateColumn<TItem> : ColumnBase<TItem, DateOnly>
{
    protected override RenderFragment<TItem> GetEditTemplate() => item => builder =>
    {
        builder.OpenComponent<RadzenDatePicker<DateOnly>>(0);
        builder.AddAttribute(1, "Value", getter!.Invoke(item));
        builder.AddAttribute(2, "ValueChanged", new EventCallback<DateOnly>(this, (DateOnly val) => setter!.Invoke(item, val)));
        builder.CloseComponent();
    };
}