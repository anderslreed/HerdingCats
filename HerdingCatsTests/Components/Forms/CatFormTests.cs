using AngleSharp.Html.Dom;

using FluentAssertions;

using HerdingCats.Components.Forms;
using HerdingCats.Data.Comparers;
using HerdingCats.Data.Model;

using HerdingCatsTests.Mocks;

using Radzen.Blazor;

namespace HerdingCatsTests.Components.Forms;

public class CatFormTests
{
    private static readonly CatEqualityComparer _comparer = new();
    private readonly InvariantCultureTestContext _testContext = new();
    private ClientInfoMocks _clientInfoMocks;

    public CatFormTests()
    {
        _clientInfoMocks = new(_testContext.Services);
        _testContext.JSInterop.SetupVoid("Radzen.createDatePicker", _ => true);
        _testContext.JSInterop.SetupVoid("Radzen.preventArrows", _ => true);
        _testContext.JSInterop.Setup<string>("Radzen.getInputValue", _ => true).SetResult("fdasgdd");
    }

    [Fact]
    public void OnFirstRender_IntakeDateIsCurrentDate()
    {
        var component = GetComponent();

        var intakeBox = component.Find("#date_new_cat_intake") as IHtmlInputElement;
        intakeBox!.Should().NotBeNull();
        var expected = DateOnly.FromDateTime(_clientInfoMocks.fakeClientDateTime).ToString();
        intakeBox!.Value.Should().Be(expected);
    }

    [Fact]
    public void OnFirstRender_AgeIsOneYear()
    {
        var component = GetComponent();

        (component.Find("#num_new_cat_age_years") as IHtmlInputElement)!.Value.Should().Be("1");
        (component.Find("#num_new_cat_age_months") as IHtmlInputElement)!.Value.Should().Be("0");
    }

    [Fact]
    public void OnSubmitClick_NewCatHasSpecifiedProperties()
    {
        var dummyDate = new DateOnly(2007, 8, 9);
        var component = GetComponent();

        component.Find("#txt_new_cat_name").Change("Kitty");
        var renderedDatePicker = component.FindComponent<RadzenDatePicker<DateOnly>>();
        void Call() => renderedDatePicker.Instance.ValueChanged.InvokeAsync(dummyDate);
        renderedDatePicker.InvokeAsync(Call);
        component.Find("#num_new_cat_age_years").Change("2");
        component.Find("#num_new_cat_age_months").Change("5");
        component.Find("#txt_new_cat_comments").Change("Pretty kitty");
        component.Find("#btn_add_new_cat").Click();

        var expected = new Cat()
        {
            Name = "Kitty",
            IntakeDate = new DateOnly(2007, 8, 9),
            BirthDate = new DateOnly(2005, 3, 9),
            IntakeComments = "Pretty kitty"
        };
        _comparer.Equals(expected, submittedCat).Should().BeTrue();
    }

    private Cat? submittedCat;
    private Task SubmitCallback(Cat cat) => Task.FromResult(submittedCat = cat);

    private IRenderedComponent<CatForm> GetComponent() =>
        _testContext.RenderComponent<CatForm>(prms => prms.Add(cf => cf.OnAddNew, SubmitCallback));
}