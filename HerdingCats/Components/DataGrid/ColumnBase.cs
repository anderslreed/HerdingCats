using System.Reflection;

using Microsoft.AspNetCore.Components;

using Radzen.Blazor;

namespace HerdingCats.Components.DataGrid;

public abstract class ColumnBase<TItem, TValue> : RadzenDataGridColumn<TItem>
{
    protected Func<TItem, TValue>? getter;
    protected Action<TItem, TValue>? setter;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        EditTemplate = GetEditTemplate();

        Type itemType = typeof(TItem);
        PropertyInfo prop = itemType.GetProperty(Property) ?? throw new KeyNotFoundException($"'{itemType}' has no property '{Property}'");
        getter = (item) => (TValue)prop.GetValue(item)!;
        setter = (item, value) => prop.SetValue(item, value);
    }

    protected abstract RenderFragment<TItem> GetEditTemplate();
}