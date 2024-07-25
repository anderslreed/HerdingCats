using AngleSharp.Dom;
using AngleSharp.Html.Dom;

using FluentAssertions;

using HerdingCats.Components.DataGrid;

using HerdingCatsTests.DataGridTests;

using Microsoft.AspNetCore.Components;

namespace HerdingCatsTests.SharedComponentTests;

public class GridTests : TestContext
{
    private readonly List<BindingTestObject> items = [
        new() { Name = "A", Value = 1 },
        new() { Name = "B", Value = 2 },
        new() { Name = "C", Value = 3 },
    ];

    [Fact]
    public void OnClick_SelectedItemUpdates()
    {
        var component = GetGrid();

        component.Find("tbody").Children[1].Children[1].Click();

        component.Instance.SelectedItem.Should().Be(items[1]);
    }

    [Fact]
    public void OnDoubleClick_EditorIsBoundToItem()
    {
        var component = GetGrid();

        component.Find("tbody").Children[1].Children[1].DoubleClick();
        component.Find("tbody").Children[1].Children[1].FindDescendant<IHtmlInputElement>()?.Change(42);

        items[1].Value.Should().Be(42);
    }

    [Fact]
    public void OnAddButtonClick_NewItemEditing()
    {
        var component = GetGrid();

        component.Find("#grid_test_btn_add").Click();

        component.Find("tbody").Children[3].FindDescendant<IHtmlInputElement>().Should().NotBeNull();
    }

    [Fact]
    public void OnDeleteButtonClick_ItemDeleted()
    {
        var component = GetGrid();

        component.Find("tbody").Children[1].Children[1].Click();
        component.Find("#grid_test_btn_del").Click();

        items.Count.Should().Be(2);
    }

    [Fact]
    public void OnNoSelection_DeletButtonDisabled()
    {
        var component = GetGrid([]);

        component.Find("#grid_test_btn_del").IsEnabled().Should().BeFalse();
    }

    private IRenderedComponent<Grid<BindingTestObject>> GetGrid(List<BindingTestObject>? data = null) => RenderComponent<Grid<BindingTestObject>>(
            ComponentParameter.CreateParameter("Data", data ?? items),
            ComponentParameter.CreateParameter("Columns", GetColumns()),
            ComponentParameter.CreateParameter("ItemFactory", () => new BindingTestObject()),
            ComponentParameter.CreateParameter("ItemName", "Test"));

    private static RenderFragment GetColumns() => builder =>
    {
        builder.OpenComponent<TextColumn<BindingTestObject>>(0);
        builder.AddAttribute(1, "Title", "Name");
        builder.AddAttribute(2, "Property", "Name");
        builder.CloseComponent();

        builder.OpenComponent<NumericColumn<BindingTestObject, int>>(3);
        builder.AddAttribute(4, "Title", "Value");
        builder.AddAttribute(5, "Property", "Value");
        builder.CloseComponent();
    };
}