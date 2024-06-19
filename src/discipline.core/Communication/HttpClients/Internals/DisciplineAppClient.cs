using System.Net.Http.Json;
using discipline.core.Communication.HttpClients.Abstractions;

namespace discipline.core.Communication.HttpClients.Internals;

internal sealed class DisciplineAppClient(
    HttpClient httpClient) : IDisciplineAppClient
{
    public Task<HttpResponseMessage> GetAsync(string path)
        => httpClient.GetAsync(path);

    public Task<HttpResponseMessage> PostAsync<T>(string path, T t) where T : class
        => httpClient.PostAsJsonAsync<T>(path, t);

    public Task<HttpResponseMessage> PutAsync<T>(string path, T t) where T : class
        => httpClient.PutAsJsonAsync<T>(path, t);
}