using FluentAssertions;

using HerdingCats.Components.Pages;

namespace HerdingCatsTests.Pages;

public class CatsPageTests : TestContext
{
    [Fact]
    public void OnRender_ShowsCats()
    {
        var component = RenderComponent<CatList>(ComponentParameter.CreateParameter("Cats", TestObjects.GetCats()));

        component.Find("tbody").Children.Length.Should().Be(3);
    }
}