using FluentAssertions;

using HerdingCats.Data.Comparers;
using HerdingCats.Data.Model;
using HerdingCats.Data.Repositories;

using HerdingCatsTests.Db;

using Microsoft.AspNetCore.Http.Connections;

namespace HerdingCatsTests.Data.Repositories;

public abstract class RepositoryIntegrationTests<TEntity, TKey> where TEntity : class
{
    protected readonly SqliteMemoryDbTestContext testContext = new();

    protected abstract IEqualityComparer<TEntity> GetComparer();

    protected abstract IRepository<TEntity, TKey> GetRepository();

    protected abstract IList<TEntity> GetTestEntities();

    protected abstract TKey GetKey(TEntity entity);

    [Fact]
    public async Task OnAdd_EntityIsRetreivable()
    {
        IRepository<TEntity, TKey> repository = GetRepository();
        TEntity entity = GetTestEntities().First();
        await repository.AddAsync(entity);

        repository = GetRepository();
        TEntity? result = await repository.GetByIdAsync(GetKey(entity));

        entity.Should().NotBeSameAs(result);
        GetComparer().Equals(entity, result).Should().BeTrue();
    }

    [Fact]
    public async Task OnDelete_EntityIsNotRetreivable()
    {
        IList<TEntity> entities = GetTestEntities();
        TEntity firstEntity = entities[0];
        IRepository<TEntity, TKey> repository = GetRepository();
        await repository.AddAsync(firstEntity);
        TEntity secondEntity = entities[1];
        await repository.AddAsync(secondEntity);

        await repository.RemoveAsync(firstEntity);

        IList<TEntity> allCats = await repository.GetAllAsync();
        allCats.Count.Should().Be(1);
        GetComparer().Equals(secondEntity, allCats.First()).Should().BeTrue();
    }

    [Fact]
    public abstract Task OnUpdate_EntityIsUpdated();
}