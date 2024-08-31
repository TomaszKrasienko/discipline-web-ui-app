using Blazored.LocalStorage;
using discipline_wasm_ui.Infrastructure.Storage.Abstractions;

namespace discipline_wasm_ui.Infrastructure.Storage.Internals;

//TODO: Cryptography
internal sealed class LocalStorageAccessor(
    ILocalStorageService storageService) : ILocalStorageAccessor
{
    public async Task SetItemAsync<T>(T t) where T : class
    {
        await storageService.SetItemAsync(t.GetType().Name, t);
    }

    public async Task<T> GetItemAsync<T>() where T : class
    {
        var item = await storageService.GetItemAsync<T>(typeof(T).Name);
        return item;
    }

    public async Task RemoveAsync<T>() where T : class
    {
        await storageService.RemoveItemAsync(typeof(T).Name);
    }
}