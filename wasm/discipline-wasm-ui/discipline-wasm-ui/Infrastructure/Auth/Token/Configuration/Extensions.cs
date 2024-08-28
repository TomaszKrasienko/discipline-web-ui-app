using discipline_wasm_ui.Infrastructure.Auth.Token.Internals;

namespace discipline_wasm_ui.Infrastructure.Auth.Token.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddTokenServices(this IServiceCollection services)
        => services.AddSingleton<ITokenProvider, TokenProvider>();
}