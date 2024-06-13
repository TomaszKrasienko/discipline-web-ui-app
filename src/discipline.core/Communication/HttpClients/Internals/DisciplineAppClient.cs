using discipline.core.Communication.HttpClients.Abstractions;

namespace discipline.core.Communication.HttpClients.Internals;

internal sealed class DisciplineAppClient : IDisciplineAppClient
{
    public Task<HttpResponseMessage> GetAsync(string path)
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> PostAsync<T>(string path, T t) where T : class
    {
        throw new NotImplementedException();
    }
}