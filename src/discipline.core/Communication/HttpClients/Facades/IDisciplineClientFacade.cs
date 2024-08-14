using discipline.core.DTOs;

namespace discipline.core.Communication.HttpClients.Facades;

public interface IDisciplineClientFacade
{
    Task<ResponseDto> ToResponseDto(HttpResponseMessage httpResponseMessage);
    Task<T> ToResult<T>(HttpResponseMessage httpResponseMessage) where T : class;
    Task<HttpResponseMessage> GetAsync(string path);
    Task<T> GetAsResultAsync<T>(string path);
    Task<ResponseDto> PostToResponseDtoAsync<T>(string path, T t) where T : class;
    Task<ResponseDto> PutToResponseDtoAsync<T>(string path, T t) where T : class;
    Task<ResponseDto> PatchToResponseDtoAsync(string path);
    Task<ResponseDto> DeleteToResponseDtoAsync(string path);
}