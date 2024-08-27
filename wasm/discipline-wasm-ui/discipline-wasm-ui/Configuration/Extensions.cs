using discipline_wasm_ui.Auth.Configuration;
using discipline_wasm_ui.Services.Configuration;
using discipline_wasm_ui.Storage.Configuration;

namespace discipline_wasm_ui.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddConfiguration(this IServiceCollection services)
        => services
            .AddServices()
            .AddStorage()
            .AddAuth();
}