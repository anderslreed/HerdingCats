using Microsoft.JSInterop;

namespace HerdingCats.Data;

public interface IClientInfo
{
    public Task<DateTime> DateTime();
}

public class ClientInfo(IJSRuntime jsRuntime) : IClientInfo
{
    public async Task<DateTime> DateTime() => await jsRuntime.InvokeAsync<DateTime>("getDateTime", []);
}