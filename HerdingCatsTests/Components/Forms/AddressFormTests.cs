using FluentAssertions;

using HerdingCats.Components.Forms;
using HerdingCats.Data.Comparers;
using HerdingCats.Data.Model;

namespace HerdingCatsTests.Components.Forms;

public class AddressFormTests
{
    private static readonly AddressEqualityComparer comparer = new();
    private readonly InvariantCultureTestContext _testContext = new();

    private Address? addedAddress;
    private Task AddAddressCallback(Address address)
    {
        addedAddress = address;
        return Task.CompletedTask;
    }

    [Fact]
    public void OnSubmitClick_NewAddressHasSpecifiedProperties()
    {
        var component = _testContext.RenderComponent<AddressForm>(prms =>
        {
            prms.Add(af => af.OnNewAddress, AddAddressCallback);
        });

        component.Find("#txt_new_addr_street").Change("22 Test Street");
        component.Find("#txt_new_addr_city").Change("Testville");
        component.Find("#num_new_addr_postal").Change("7000");
        component.Find("#btn_new_addr_add").Click();

        Address expected = new()
        {
            Street = "22 Test Street",
            City = "Testville",
            PostalCode = 7000,
        };
        comparer.Equals(expected, addedAddress).Should().BeTrue();
    }
}