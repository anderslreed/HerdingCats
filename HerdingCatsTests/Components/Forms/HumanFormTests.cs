using HerdingCats.Components.Forms;
using HerdingCats.Data.Comparers;
using HerdingCats.Data.Model;

namespace HerdingCatsTests.Components.Forms;

public class HumanFormTests
{
    private static readonly HumanEqualityComparer comparer = new();
    private readonly InvariantCultureTestContext _testContext = new();

    private Human? addedHuman;
    private Task NewHumanCallback(Human human)
    {
        addedHuman = human;
        return Task.CompletedTask;
    }

    [Fact]
    public void OnSubmitClick_NewHumanHasSpecifiedProperties()
    {
        IRenderedComponent<HumanForm> component = _testContext.RenderComponent<HumanForm>(prms => 
        {
            prms.Add(hf => hf.OnNewHuman, NewHumanCallback);
        });
        
        component.Find("#txt_new_user_first_name").Change("Skippy");
        component.Find("#txt_new_user_last_name").Change("McSkipperson");
        component.Find("#num_new_user_phone").Change("12345678");

        Human expected = new()
        {
            FirstName = "Skippy",
            LastName = "McSkipperson",
            PhoneNumber = "12345678"
        };
        comparer.Equals(expected, addedHuman);
    }
}