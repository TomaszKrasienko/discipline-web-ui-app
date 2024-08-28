using discipline_wasm_ui.Infrastructure.Services.Client.Configuration;
using discipline_wasm_ui.Infrastructure.Services.Dispatchers.Configuration;

namespace discipline_wasm_ui.Infrastructure.Services.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddClients()
            .AddDispatchers();
}