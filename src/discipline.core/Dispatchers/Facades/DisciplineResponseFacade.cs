using System.Net;
using System.Net.Http.Json;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Facades;

internal sealed class DisciplineResponseFacade(
    IDisciplineAppClient disciplineAppClient) : IDisciplineClientFacade
{
    public async Task<HttpResponseMessage> GetAsync(string path)
    {
        var response = await disciplineAppClient.GetAsync(path); 
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException();
        }
        return response;
    }

    public async Task<T> GetAsResultAsync<T>(string path)
        => await (await GetAsync(path)).Content.ReadFromJsonAsync<T>();

    public async Task<ResponseDto> PostToResponseDtoAsync<T>(string path, T t) where T : class
        => await ToResponseDto(await disciplineAppClient.PostAsync(path, t));

    public async Task<ResponseDto> PutToResponseDtoAsync<T>(string path, T t) where T : class
        => await ToResponseDto(await disciplineAppClient.PutAsync(path, t));

    public async Task<ResponseDto> PatchToResponseDtoAsync(string path)
        => await ToResponseDto(await disciplineAppClient.PatchAsync(path));

    public async Task<ResponseDto> DeleteToResponseDtoAsync(string path)
        => await ToResponseDto(await disciplineAppClient.DeleteAsync(path));
    
    private static async Task<ResponseDto> ToResponseDto(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException();
        }

        return response.StatusCode switch
        {
            HttpStatusCode.OK or HttpStatusCode.Created
                => ResponseDto.GetValid(),
            HttpStatusCode.BadRequest or HttpStatusCode.UnprocessableEntity 
                => ResponseDto.GetInvalid((await response.Content.ReadFromJsonAsync<ErrorResponseDto>()).Message),
            _
                => ResponseDto.GetInvalid()
        }; 
    }
}