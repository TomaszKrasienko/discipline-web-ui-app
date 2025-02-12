using Microsoft.AspNetCore.SignalR.Client;

namespace discipline_wasm_ui.Infrastructure.SignalR.Client.Abstractions;

public interface IHubClient
{
    Task<HubConnection> Get();
}