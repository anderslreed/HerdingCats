using System.ComponentModel.DataAnnotations;
using System.Configuration;

using AngleSharp.Dom;
using AngleSharp.Html.Dom;

using FluentAssertions;

using HerdingCats.Components.Shared;
using HerdingCats.Data.Model;

using Microsoft.AspNetCore.Components;

using Radzen.Blazor;

namespace HerdingCatsTests.Components.Shared;

public class NullableEnumDropDownTests
{
    private readonly InvariantCultureTestContext _testContext = new();

    private enum TestEnum
    {
        [Display(Name = "Option one")]
        First,
        [Display(Name = "Option two")]
        Second,
        [Display(Name = "Option three")]
        Third
    }

    public NullableEnumDropDownTests()
    {
        _testContext.JSInterop.SetupVoid("Radzen.preventArrows", _ => true);
        _testContext.JSInterop.SetupVoid("Radzen.closePopup", _ => true);
        _testContext.JSInterop.SetupVoid("Radzen.togglePopup", _ => true);
    }

    [Fact]
    public void OnRender_DisplaysElements()
    {
        var component = _testContext.RenderComponent<NullableEnumDropDown<TestEnum>>();

        var options = component.Find("ul").Children
                               .Where(ch => ch is IHtmlListItemElement)
                               .Select(ch => ch.FindDescendant<IHtmlSpanElement>()?.InnerHtml)
                               .ToList();

        options.Should().Contain(["", "Option one", "Option two", "Option three"]);       
    }

    [Fact]
    public void OnSelectValueCalled_UpdatesSelection()
    {
        var component = _testContext.RenderComponent<NullableEnumDropDown<TestEnum>>();

        component.Instance.SelectValue(TestEnum.Second);
        component.FindComponent<RadzenDropDown<TestEnum?>>().Render();

        component.Find("input").GetAttribute("value").Should().Be("Second");
    }

    [Fact]
    public void OnSetSelectedValueNull_BlankOptionSelected()
    {
        var component = _testContext.RenderComponent<NullableEnumDropDown<TestEnum>>();

        component.Instance.SelectValue(TestEnum.Second);
        component.Instance.SelectValue(null);
        component.FindComponent<RadzenDropDown<TestEnum?>>().Render();

        component.Find("input").GetAttribute("value").Should().Be("");
    }

    [Fact]
    public void OnSelectionChanged_UpdatesBoundValue()
    {
        DummyHandler handler = new();
        var component = _testContext.RenderComponent<NullableEnumDropDown<TestEnum>>(prms =>
        {
            prms.Add(dd => dd.ValueChanged, handler.GetCallback());
        });
        var dropDown = component.FindComponent<RadzenDropDown<TestEnum?>>().Instance;
        dropDown.SelectDropDownIndex(1);

        handler.valueChangedTarget.Should().Be(TestEnum.First);
    }

    

    private class DummyHandler : IHandleEvent
    {
        public TestEnum? valueChangedTarget = null;

        public async Task HandleEventAsync(EventCallbackWorkItem item, object? arg) => await item.InvokeAsync(arg);

        public EventCallback<TestEnum?> GetCallback() => new(this, Callback);

        private void Callback(TestEnum? value) => valueChangedTarget = value;
    }
}