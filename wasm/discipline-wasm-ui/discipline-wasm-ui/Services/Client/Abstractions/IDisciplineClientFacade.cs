using discipline_wasm_ui.Services.DTOs;

namespace discipline_wasm_ui.Services.Client.Abstractions;

public interface IDisciplineClientFacade
{
    Task<HttpResponseMessage> GetAsync(string path);
    Task<T?> GetAsResultAsync<T>(string path) where T : class;
    Task<ResponseDto> PostToResponseDtoAsync<T>(string path, T t) where T : class;
    Task<ResponseDto> PutToResponseDtoAsync<T>(string path, T t) where T : class;
    Task<ResponseDto> PatchToResponseDtoAsync(string path);
    Task<ResponseDto> DeleteToResponseDtoAsync(string path);
}