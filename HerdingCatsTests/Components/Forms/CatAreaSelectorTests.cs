using FluentAssertions;

using HerdingCats.Components.Forms;
using HerdingCats.Data.Model;

using HerdingCatsTests.Components.Shared;

using Radzen.Blazor;

namespace HerdingCatsTests.Components.Forms;

public class CatAreaSelectorTests
{
    private readonly InvariantCultureTestContext _testContext = new();

    public CatAreaSelectorTests() => _testContext.JSInterop.SetupVoid("Radzen.preventArrows", _ => true);

    [Fact]
    public void OnSelectCatAreaOther_ShowsAdditionalTextBox()
    {
        Report report = new();
        IRenderedComponent<CatAreaSelector> component = _testContext.RenderComponent<CatAreaSelector>(prms => {
            prms.Add(cas => cas.CurrentReport, report);
        });
        
        component.FindComponent<RadzenDropDown<CatAreas?>>().Instance.SelectDropDownIndex(5);

        component.Markup.Should().Contain("txt_report_other_area");
    }
}