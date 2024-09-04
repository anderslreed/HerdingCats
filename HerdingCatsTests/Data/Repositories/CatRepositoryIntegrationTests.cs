using FluentAssertions;

using HerdingCats.Data.Comparers;
using HerdingCats.Data.Model;
using HerdingCats.Data.Repositories;

using HerdingCatsTests.Db;

namespace HerdingCatsTests.Data.Repositories;

public class CatRepositoryIntegrationTests : RepositoryIntegrationTests<Cat, int>
{
    private static readonly CatEqualityComparer _catComparer = new();
    private readonly TestObjects _testObjects = new();

    protected override IEqualityComparer<Cat> GetComparer() => _catComparer;
    protected override int GetKey(Cat entity) => entity.Id;
    protected override IRepository<Cat, int> GetRepository() => new CatRepository(testContext.GetDbContext());
    protected override IList<Cat> GetTestEntities() => new TestObjects().cats;

    [Fact]
    public async override Task OnUpdate_EntityIsUpdated()
    {
        IRepository<Cat, int> repository = GetRepository();
        Cat cat = _testObjects.cats[0];
        await repository.AddAsync(cat);

        cat.Name = "New name";
        await repository.UpdateAsync(cat);
        Cat? result = await repository.GetByIdAsync(cat.Id);

        result!.Name.Should().Be("New name");
        _catComparer.Equals(cat, result).Should().BeTrue();
    }
}