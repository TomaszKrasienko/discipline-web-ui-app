using discipline_wasm_ui.Infrastructure.SignalR.Client.Abstractions;

namespace discipline_wasm_ui.Infrastructure.SignalR.Client.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddSignalRClient(this IServiceCollection services)
        => services.AddSingleton<IHubClient, HubClient>();
}