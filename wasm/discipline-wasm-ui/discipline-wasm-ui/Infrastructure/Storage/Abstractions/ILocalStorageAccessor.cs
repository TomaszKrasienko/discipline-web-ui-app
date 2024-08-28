namespace discipline_wasm_ui.Infrastructure.Storage.Abstractions;

internal interface ILocalStorageAccessor
{
    Task SetItemAsync<T>(T t) where T : class;
    Task<T> GetItemAsync<T>() where T : class;
}