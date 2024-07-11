using FluentAssertions;
using HerdingCats.Data;
using HerdingCats.Data.Model;

namespace HerdingCatsTests.Db;

public class DbIntegrationTests : SqliteMemoryDbTest
{
    [Fact]
    public void OnPersistGraph_RetrievedGraphIsEqual()
    {
        using KittyDbContext addContext = Services.GetService<KittyDbContext>() ?? throw new Exception();
        addContext.Database.EnsureCreated();
        List<Address> addresses = TestObjects.GetAddresses();
        addContext.AddRange(addresses);
        addContext.SaveChanges();

        using KittyDbContext retrieveContext = Services.GetService<KittyDbContext>() ?? throw new Exception();
        IList<Address>? result = [.. retrieveContext.Set<Address>()];

        result.Should().Equal(addresses);
    }
}