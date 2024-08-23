using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Helpers.Abstractions;

namespace discipline.core.Communication.HttpClients.Internals;

internal sealed class DisciplineAppClient(
    HttpClient httpClient,
    ITokenStorage tokenStorage) : IDisciplineAppClient
{
    public async Task<HttpResponseMessage> GetAsync(string path)
    {
        Authorize();
        var result = await httpClient.GetAsync(path);
        
    }

    private async Task<HttpResponseMessage> Refresh(HttpResponseMessage httpResponseMessage)
    {
        if (httpResponseMessage.StatusCode is not HttpStatusCode.Unauthorized)
            return httpResponseMessage;
        
    }

    public Task<HttpResponseMessage> PostAsync<T>(string path, T t) where T : class
    {
        Authorize();
        return httpClient.PostAsJsonAsync<T>(path, t);
    }

    public Task<HttpResponseMessage> PutAsync<T>(string path, T t) where T : class
    {
        Authorize();
        return httpClient.PutAsJsonAsync<T>(path, t);
    }

    public Task<HttpResponseMessage> PatchAsync(string path)
    {
        Authorize();
        return httpClient.PatchAsync(path, null);
    }

    public Task<HttpResponseMessage> DeleteAsync(string path)
    {
        Authorize();
        return httpClient.DeleteAsync(path);
    }

    private void Authorize()
    {
        var token = tokenStorage.Get();
        if (!string.IsNullOrWhiteSpace(token))
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        }
    }
}