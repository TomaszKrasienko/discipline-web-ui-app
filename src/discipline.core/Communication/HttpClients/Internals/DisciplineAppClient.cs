using discipline.core.Communication.HttpClients.Abstractions;

namespace discipline.core.Communication.HttpClients.Internals;

internal sealed class DisciplineAppClient : IDisciplineAppClient
{
    public Task<T> GetAsync<T>(string path) where T : class
    {
        throw new NotImplementedException();
    }

    public Task PostAsync<T>(string path, T t) where T : class
    {
        throw new NotImplementedException();
    }
}