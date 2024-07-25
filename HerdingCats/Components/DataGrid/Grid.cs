using Microsoft.AspNetCore.Components;

using Radzen;
using Radzen.Blazor;

namespace HerdingCats.Components.DataGrid;

public class Grid<TItem> : RadzenDataGrid<TItem>
{
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
        Initialize();
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Initialize();
    }

    private void Initialize()
    {
        CellDoubleClick = new EventCallback<DataGridCellMouseEventArgs<TItem>>(this, OnCellDoubleClick);
        SelectionMode = DataGridSelectionMode.Single;
        Value = SelectedList;
        ValueChanged = new EventCallback<IList<TItem>>(this, (List<TItem> val) => SelectedList = val);
    }

    private void OnCellDoubleClick(DataGridCellMouseEventArgs<TItem> args)
    {
        SelectedItem = args.Data;
        EditRow(args.Data);
    }
}