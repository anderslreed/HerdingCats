using HerdingCats.Data;

using Microsoft.Extensions.DependencyInjection;

using Moq;

namespace HerdingCatsTests.Mocks;

public class ClientInfoMocks
{
    public readonly DateTime fakeClientDateTime = new(2000, 2, 3);
    public readonly Mock<IClientInfo> mockClientInfo = new(MockBehavior.Strict);

    public ClientInfoMocks(IServiceCollection services)
    {
        mockClientInfo.Setup(ci => ci.DateTime()).Returns(Task.FromResult(fakeClientDateTime));
        services.AddScoped(prv => mockClientInfo.Object);
    }
}