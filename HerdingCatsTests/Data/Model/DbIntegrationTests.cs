using FluentAssertions;

using HerdingCats.Data;
using HerdingCats.Data.Model;

using Microsoft.EntityFrameworkCore;

namespace HerdingCatsTests.Db;

public class DbIntegrationTests
{
    private readonly SqliteMemoryDbTestContext _testContext = new();

    [Fact]
    public void OnPersistGraph_RetrievedGraphIsEqual()
    {
        TestObjects testObjects = new();

        using KittyDbContext addContext = _testContext.Services.GetService<KittyDbContext>() ?? throw new Exception();
        addContext.Database.EnsureCreated();
        addContext.AddRange(testObjects.humans);
        addContext.AddRange(testObjects.cats);
        addContext.SaveChanges();
        using KittyDbContext retrieveContext = _testContext.Services.GetService<KittyDbContext>() ?? throw new Exception();
        DbSet<Human>? humans = retrieveContext.Set<Human>();
        DbSet<Cat>? cats = retrieveContext.Set<Cat>();

        humans.Should().Equal(testObjects.humans);
        cats.Should().Equal(testObjects.cats);
    }
}