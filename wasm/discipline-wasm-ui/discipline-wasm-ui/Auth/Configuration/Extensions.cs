using discipline_wasm_ui.Auth.Token.Configuration;

namespace discipline_wasm_ui.Auth.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddAuth(this IServiceCollection services)
        => services
            .AddTokenServices()
            .AddSingleton<CustomAuthenticationStateProvider>();
}