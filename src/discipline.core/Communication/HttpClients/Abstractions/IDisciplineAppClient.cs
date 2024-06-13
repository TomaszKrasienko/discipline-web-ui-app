namespace discipline.core.Communication.HttpClients.Abstractions;

public interface IDisciplineAppClient
{
    Task<HttpResponseMessage> GetAsync(string path);
    Task<HttpResponseMessage> PostAsync<T>(string path, T t) where T : class;
}