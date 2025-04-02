using discipline_wasm_ui.Infrastructure.Auth.Token.Internals;
using discipline.ui.infrastructure.Auth.Configuration;
using discipline.ui.infrastructure.Auth.Tokens.Abstractions;

namespace discipline_wasm_ui.Infrastructure.Auth.Token.Configuration;

internal static class Extensions
{
    internal static IServiceCollection SetAuthServices(this IServiceCollection services)
        => services
            .SetInfrastructureAuthServices()
            .AddSingleton<ITokenHandler, TokenHandler>();
}