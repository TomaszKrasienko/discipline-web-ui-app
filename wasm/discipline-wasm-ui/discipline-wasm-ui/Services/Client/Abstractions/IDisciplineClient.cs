namespace discipline_wasm_ui.Services.Client.Abstractions;

internal interface IDisciplineClient
{
    Task<HttpResponseMessage> GetAsync(string path);
    Task<HttpResponseMessage> PostAsync<T>(string path, T t) where T : class;
    Task<HttpResponseMessage> PutAsync<T>(string path, T t) where T : class;
    Task<HttpResponseMessage> PatchAsync(string path);
    Task<HttpResponseMessage> DeleteAsync(string path);
}