using FluentAssertions;

using HerdingCats.Data.Comparers;
using HerdingCats.Data.Model;
using HerdingCats.Data.Repositories;

using HerdingCatsTests.Db;

namespace HerdingCatsTests.Data.Repositories;

public class CatRepositoryIntegrationTests
{
    private static readonly CatEqualityComparer _catComparer = new();
    private readonly SqliteMemoryDbTestContext _testContext = new();
    private readonly TestObjects _testObjects = new();
    private CatRepository _repository;

    public CatRepositoryIntegrationTests() => _repository = new(_testContext.GetDbContext());

    [Fact]
    public async Task OnCreateCat_CatIsRetreivable()
    {
        Cat cat = _testObjects.cats[0];
        await _repository.AddAsync(cat);

        _repository = new(_testContext.GetDbContext());
        Cat? result = await  _repository.GetByIdAsync(cat.Id);

        cat.Should().NotBeSameAs(result);
        _catComparer.Equals(cat, result).Should().BeTrue();
    }

    [Fact]
    public async Task OnDeleteCat_CatIsNotRetreivable()
    {
        Cat firstCat = _testObjects.cats[0];
        await _repository.AddAsync(firstCat);
        Cat secondCat = _testObjects.cats[1];
        await _repository.AddAsync(secondCat);

        await _repository.RemoveAsync(firstCat);

        IList<Cat> allCats = await _repository.GetAllAsync();
        allCats.Count.Should().Be(1);
        _catComparer.Equals(secondCat, allCats.First()).Should().BeTrue();
    }

    [Fact]
    public async Task OnUpdateCat_CatIsUpdated()
    {
        Cat cat = _testObjects.cats[0];
        await _repository.AddAsync(cat);

        cat.Name = "New name";
        await _repository.UpdateAsync(cat);
        Cat? result = await _repository.GetByIdAsync(cat.Id);

        result!.Name.Should().Be("New name");
        _catComparer.Equals(cat, result).Should().BeTrue();
    }
}