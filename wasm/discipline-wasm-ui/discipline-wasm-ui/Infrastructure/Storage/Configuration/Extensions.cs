using Blazored.LocalStorage;
using discipline_wasm_ui.Infrastructure.Storage.Abstractions;
using discipline_wasm_ui.Infrastructure.Storage.Internals;

namespace discipline_wasm_ui.Infrastructure.Storage.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddStorage(this IServiceCollection services)
        => services
            .AddBlazoredLocalStorageAsSingleton()
            .AddSingleton<ILocalStorageAccessor, LocalStorageAccessor>();
}