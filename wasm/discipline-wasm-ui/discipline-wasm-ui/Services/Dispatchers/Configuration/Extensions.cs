using discipline_wasm_ui.Services.Dispatchers.Internals;
using discipline_wasm_ui.Services.DTOs;

namespace discipline_wasm_ui.Services.Dispatchers.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddDispatchers(this IServiceCollection services)
        => services
            .AddSingleton<IUserDispatcher, DisciplineUserDispatcher>()
            .AddSingleton<IActivityRulesDispatcher, DisciplineActivityRulesDispatcher>();
}