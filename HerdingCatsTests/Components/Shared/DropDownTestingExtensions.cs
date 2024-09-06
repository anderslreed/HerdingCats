using Radzen.Blazor;

namespace HerdingCatsTests.Components.Shared;

public static class DropDownTestingExtensions
{
    public static void SelectDropDownIndex<T>(this RadzenDropDown<T> dropDown, int index)
    {
        var targetItem = dropDown.Data.Cast<object>()
                                              .Where((x, idx) => idx == index)
                                              .First();

        dropDown.SelectItem(targetItem);
    }
}