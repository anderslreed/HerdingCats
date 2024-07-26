using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Radzen;
using Radzen.Blazor;

namespace HerdingCats.Components.DataGrid;

public class Grid<TItem> : RadzenDataGrid<TItem>
{
    [Parameter]
    public Func<TItem>? ItemFactory { get; set; }

    [Parameter]
    public string ItemName { get; set; } = "";

    public TItem? SelectedItem
    {
        get => _selectedItem;
        private set => _selectedItem = value;
    }

    private IList<TItem> SelectedList
    {
        get => _selectedItem is null ? [] : [_selectedItem];
        set => _selectedItem = value.First();
    }

    private TItem? _selectedItem;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        
        CellDoubleClick = new EventCallback<DataGridCellMouseEventArgs<TItem>>(this, OnCellDoubleClick);
        FooterTemplate  = GetFooterTemplate();
        SelectionMode = DataGridSelectionMode.Single;
        Value = SelectedList;
        ValueChanged = new EventCallback<IList<TItem>>(this, (List<TItem> val) => SelectedList = val);
    }

    private RenderFragment GetFooterTemplate() => builder =>
    {
        builder.OpenComponent<RadzenButton>(0);
        builder.AddAttribute(1, "Text", $"New");
        builder.AddAttribute(2, "Click", new EventCallback<MouseEventArgs>(this, OnAddButtonClick));
        builder.AddAttribute(3, "Icon", "add_circle");
        builder.AddAttribute(4, "aria-text", $"Add new {ItemName}");
        builder.AddAttribute(5, "id", $"grid_{ItemName.ToLower()}_btn_add");
        builder.CloseComponent();

        builder.OpenComponent<RadzenButton>(6);
        builder.AddAttribute(7, "Text", $"Delete");
        builder.AddAttribute(8, "Click", new EventCallback<MouseEventArgs>(this, OnDeleteButtonClick));
        builder.AddAttribute(9, "Icon", "add_circle");
        builder.AddAttribute(10, "aria-text", $"Delete selected {ItemName}");
        builder.AddAttribute(11, "id", $"grid_{ItemName.ToLower()}_btn_del");
        builder.AddAttribute(12, "Disabled", _selectedItem is null);
        builder.CloseComponent();
    };

    private void OnCellDoubleClick(DataGridCellMouseEventArgs<TItem> args)
    {
        SelectedItem = args.Data;
        EditRow(args.Data);
    }

    private async void OnAddButtonClick()
    {
        if (Data is ICollection<TItem> collection && ItemFactory is not null)
        {
            TItem item = ItemFactory();
            collection.Add(item);
            await RefreshDataAsync();
            await EditRow(item);
        }
    }

    private async void OnDeleteButtonClick()
    {
        if (Data is ICollection<TItem> collection && _selectedItem is not null)
        {
            collection.Remove(_selectedItem);
            await RefreshDataAsync();
            _selectedItem = default;
        }
    }
}