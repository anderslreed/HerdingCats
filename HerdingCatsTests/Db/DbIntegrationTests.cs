using FluentAssertions;

using HerdingCats.Data;
using HerdingCats.Data.Model;

using Microsoft.EntityFrameworkCore;

namespace HerdingCatsTests.Db;

public class DbIntegrationTests : SqliteMemoryDbTest
{
    [Fact]
    public void OnPersistGraph_RetrievedGraphIsEqual()
    {
        TestObjects testObjects = new();

        using KittyDbContext addContext = Services.GetService<KittyDbContext>() ?? throw new Exception();
        addContext.Database.EnsureCreated();
        addContext.AddRange(testObjects.humans);
        addContext.AddRange(testObjects.cats);
        addContext.SaveChanges();
        using KittyDbContext retrieveContext = Services.GetService<KittyDbContext>() ?? throw new Exception();
        DbSet<Human>? humans = retrieveContext.Set<Human>();
        DbSet<Cat>? cats = retrieveContext.Set<Cat>();

        humans.Should().Equal(testObjects.humans);
        cats.Should().Equal(testObjects.cats);
    }
}