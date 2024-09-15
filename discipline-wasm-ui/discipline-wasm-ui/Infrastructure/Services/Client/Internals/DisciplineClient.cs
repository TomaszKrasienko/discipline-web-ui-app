using System.Net.Http.Headers;
using System.Net.Http.Json;
using discipline_wasm_ui.Infrastructure.Services.Client.Abstractions;
using discipline_wasm_ui.Infrastructure.Services.DTOs;
using discipline_wasm_ui.Infrastructure.Storage.Abstractions;

namespace discipline_wasm_ui.Infrastructure.Services.Client.Internals;

internal sealed class DisciplineClient(
    HttpClient httpClient,
    ILocalStorageAccessor localStorageAccessor) : IDisciplineClient
{
    public async Task<HttpResponseMessage> GetAsync(string path)
    {
        await Authorize();
        return await httpClient.GetAsync(path);
    }

    public async Task<HttpResponseMessage> PostAsync<T>(string path, T t) where T : class
    {
        await Authorize();
        return await httpClient.PostAsJsonAsync<T>(path, t);
    }

    public async Task<HttpResponseMessage> PutAsync<T>(string path, T t) where T : class
    { 
        await Authorize();
        return await httpClient.PutAsJsonAsync<T>(path, t);
    }

    public async Task<HttpResponseMessage> PatchAsync(string path)
    { 
        await Authorize();
        return await httpClient.PatchAsync(path, null);
    }

    public async Task<HttpResponseMessage> DeleteAsync(string path)
    {
        await Authorize();
        return await httpClient.DeleteAsync(path);
    }

    private async Task Authorize()
    {
        var tokens = await localStorageAccessor.GetItemAsync<TokensDto>();
        if (tokens is not null)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokens.Token);
        }
    }
}