using FluentAssertions;

using HerdingCats.Components.Pages;
using HerdingCats.Data.Model;
using HerdingCats.Data.Repositories;

using Moq;

namespace HerdingCatsTests.Pages;

public class AdminCatListTests : TestContext
{
    private readonly Mock<IRepository<Cat, int>> _mockRepository = new(MockBehavior.Strict);

    public AdminCatListTests()
    {
        JSInterop.SetupVoid("Radzen.preventArrows", _ => true);
        JSInterop.SetupVoid("Radzen.createDatePicker", _ => true);
    }

    [Fact]
    public void OnRender_ShowsCats()
    {
        TestObjects testObjects = new();
        _mockRepository.Setup(rep => rep.GetAllAsync()).Returns(Task.FromResult((IList<Cat>)testObjects.cats));

        var component = RenderComponent<AdminCatList>(ComponentParameter.CreateParameter("Repository", _mockRepository.Object));

        component.Find("tbody").Children.Length.Should().Be(3);
    }
}