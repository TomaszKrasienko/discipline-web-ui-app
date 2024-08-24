using System.Net.Http.Headers;
using discipline.ui.Communication.Helpers.Abstractions;
using discipline.ui.Communication.HttpClients.Abstractions;

namespace discipline.ui.Communication.HttpClients.Internals;

internal sealed class DisciplineAppClient(
    HttpClient httpClient,
    ITokenStorage tokenStorage) : IDisciplineAppClient
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
        var tokens = await tokenStorage.Get();
        if (tokens is not null)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokens.Token);
        }
    }
}