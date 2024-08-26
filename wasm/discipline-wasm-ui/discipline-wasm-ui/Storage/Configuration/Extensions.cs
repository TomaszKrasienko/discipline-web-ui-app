using Blazored.LocalStorage;
using discipline_wasm_ui.Storage.Abstractions;
using discipline_wasm_ui.Storage.Internals;

namespace discipline_wasm_ui.Storage.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddStorage(this IServiceCollection services)
        => services
            .AddBlazoredLocalStorageAsSingleton()
            .AddSingleton<ILocalStorageAccessor, LocalStorageAccessor>();
}