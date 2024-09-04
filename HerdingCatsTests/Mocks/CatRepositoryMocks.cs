using HerdingCats.Data.Model;
using HerdingCats.Data.Repositories;

using Microsoft.Extensions.DependencyInjection;

using Moq;

namespace HerdingCatsTests.Mocks;

public class CatRepositoryMocks
{
    public readonly Mock<IRepository<Cat, int>> mockRepository = new(MockBehavior.Strict);

    public CatRepositoryMocks(IServiceCollection services)
    {
        TestObjects testObjects = new();
        mockRepository.Setup(rep => rep.GetAllAsync()).Returns(Task.FromResult(testObjects.cats));
        services.AddScoped(prv => mockRepository.Object);
    }
}