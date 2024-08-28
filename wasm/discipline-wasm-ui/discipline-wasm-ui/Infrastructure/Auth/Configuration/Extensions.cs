using discipline_wasm_ui.Infrastructure.Auth.Token.Configuration;
using Microsoft.AspNetCore.Components.Authorization;

namespace discipline_wasm_ui.Infrastructure.Auth.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddAuth(this IServiceCollection services)
        => services
            .AddTokenServices()
            .AddSingleton<CustomAuthenticationStateProvider>()
            .AddSingleton<AuthenticationStateProvider>(sp 
                => sp.GetRequiredService<CustomAuthenticationStateProvider>());
}