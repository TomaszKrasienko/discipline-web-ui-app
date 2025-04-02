using discipline_wasm_ui.Infrastructure.Auth.Token;
using discipline_wasm_ui.Infrastructure.SignalR.Client.Abstractions;
using discipline.ui.infrastructure.Auth.Tokens.Abstractions;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;

namespace discipline_wasm_ui.Infrastructure.SignalR.Client;

internal sealed class HubClient(
    ITokenHandler tokenHandler,
    IOptions<SignalROptions> options) : IHubClient
{
    private readonly string _url = options.Value.Url;
    
    public async Task<HubConnection> Get()
    {
        var token = await tokenHandler.GetTokenAsync();
        return new HubConnectionBuilder()
            .WithUrl(_url, opt =>
            {
                opt.AccessTokenProvider = () => Task.FromResult(token);
            })
            .WithAutomaticReconnect()
            .Build();
    }
}