using Microsoft.AspNetCore.Components;

namespace HerdingCats.Components.Forms;

public class FormBase<TItem> : ComponentBase where TItem : new()
{
    [Parameter]
    [EditorRequired]
    public Func<TItem, Task>? OnAddNew { get; set; }

    protected TItem addingItem = new();

    protected async Task AddNew()
    {
        await OnAddNew!.Invoke(addingItem);
        addingItem = new();
    }
}