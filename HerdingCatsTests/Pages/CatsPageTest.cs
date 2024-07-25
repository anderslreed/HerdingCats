using FluentAssertions;

using HerdingCats.Components.Pages;

namespace HerdingCatsTests.Pages;

public class CatsPageTests : TestContext
{
    [Fact]
    public void OnRender_ShowsCats()
    {
        TestObjects testObjects = new();
        var component = RenderComponent<CatList>(ComponentParameter.CreateParameter("Cats", testObjects.cats));

        component.Find("tbody").Children.Length.Should().Be(3);
    }
}