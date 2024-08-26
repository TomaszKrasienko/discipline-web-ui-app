using discipline_wasm_ui.Services.Client.Abstractions;

namespace discipline_wasm_ui.Services.Client.Internals;

internal sealed class DisciplineClient : IDisciplineClient
{
    public Task<HttpResponseMessage> GetAsync(string path)
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> PostAsync<T>(string path, T t) where T : class
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> PutAsync<T>(string path, T t) where T : class
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> PatchAsync(string path)
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteAsync(string path)
    {
        throw new NotImplementedException();
    }
}