using Microsoft.AspNetCore.Components;

using Radzen.Blazor;

namespace HerdingCats.Components.DataGrid;

public class TextColumn<TItem> : ColumnBase<TItem, string>
{
    protected override RenderFragment<TItem> GetEditTemplate() => item => builder =>
    {
        builder.OpenComponent<RadzenTextBox>(0);
        builder.AddAttribute(1, "Value", getter!(item));
        builder.AddAttribute(2, "ValueChanged", new EventCallback<string>(this, (string v) => setter!(item, v)));
        builder.CloseComponent();
    };
}