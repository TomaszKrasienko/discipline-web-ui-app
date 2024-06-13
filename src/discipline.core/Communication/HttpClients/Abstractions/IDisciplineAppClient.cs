namespace discipline.core.Communication.HttpClients.Abstractions;

public interface IDisciplineAppClient
{
    Task<T> GetAsync<T>(string path) where T : class;
    Task PostAsync<T>(string path, T t) where T : class;
}