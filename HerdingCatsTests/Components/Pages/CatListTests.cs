using FluentAssertions;

using HerdingCats.Components.Pages;

using HerdingCatsTests.Components;
using HerdingCatsTests.Mocks;

namespace HerdingCatsTests.Pages;

public class CatListTests
{
    private readonly InvariantCultureTestContext _testContext = new();

    // Mocks are injected into TestContext.Services in their constructors
    private readonly ClientInfoMocks _clientInfoMocks;
    private readonly CatRepositoryMocks _repositoryMocks;

    public CatListTests()
    {
        _clientInfoMocks = new(_testContext.Services);
        _repositoryMocks = new(_testContext.Services);
        _testContext.JSInterop.Mode = JSRuntimeMode.Loose;
    }

    [Fact]
    public void OnRender_ShowsCats()
    {
        var component = _testContext.RenderComponent<CatList>();

        component.Find("tbody").Children.Length.Should().Be(3);
    }
}