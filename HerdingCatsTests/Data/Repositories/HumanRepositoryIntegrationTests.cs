using FluentAssertions;

using HerdingCats.Data.Comparers;
using HerdingCats.Data.Model;
using HerdingCats.Data.Repositories;

namespace HerdingCatsTests.Data.Repositories;

public class HumanRepositoryIntegrationTests : RepositoryIntegrationTests<Human, int>
{
    private static readonly HumanEqualityComparer _comparer = new();

    protected override IEqualityComparer<Human> GetComparer() => _comparer;
    protected override int GetKey(Human entity) => entity.Id;
    protected override IRepository<Human, int> GetRepository() => new HumanRepository(testContext.GetDbContext());
    protected override IList<Human> GetTestEntities() => new TestObjects().humans;

    [Fact]
    public async override Task OnUpdate_EntityIsUpdated()
    {
        var repository = GetRepository();
        TestObjects testObjects = new();
        Human human = testObjects.humans[0];
        await repository.AddAsync(human);

        human.LastName = "Newname";
        await repository.UpdateAsync(human);
        Human? result = await repository.GetByIdAsync(human.Id);

        result!.LastName.Should().Be("Newname");
        _comparer.Equals(human, result).Should().BeTrue();
    }

    
}