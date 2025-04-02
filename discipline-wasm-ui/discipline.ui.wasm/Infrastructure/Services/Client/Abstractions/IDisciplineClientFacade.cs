using discipline_wasm_ui.Infrastructure.Services.DTOs;

namespace discipline_wasm_ui.Infrastructure.Services.Client.Abstractions;

public interface IDisciplineClientFacade
{
    Task<HttpResponseMessage> GetAsync(string path);
    Task<T> GetAsResultAsync<T>(string path) where T : class;
    Task<ResponseDto> PostToResponseDtoAsync<T>(string path, T t, string successMessage = null) where T : class;
    Task<ResponseDto> PutToResponseDtoAsync<T>(string path, T t, string successMessage = null) where T : class;
    Task<ResponseDto> PatchToResponseDtoAsync(string path, string successMessage = null);
    Task<ResponseDto> PatchToResponseDtoAsync<T>(string path, T t, string successMessage = null) where T : class;
    Task<ResponseDto> DeleteToResponseDtoAsync(string path, string successMessage = null);
}