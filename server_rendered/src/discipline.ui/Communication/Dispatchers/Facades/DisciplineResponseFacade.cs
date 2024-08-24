using System.Net;
using discipline.ui.Communication.DTOs;
using discipline.ui.Communication.Exceptions;
using discipline.ui.Communication.HttpClients.Abstractions;

namespace discipline.ui.Communication.Dispatchers.Facades;

internal sealed class DisciplineResponseFacade(
    IDisciplineAppClient disciplineAppClient) : IDisciplineClientFacade
{
    public async Task<HttpResponseMessage> GetAsync(string path)
    {
        var response = await disciplineAppClient.GetAsync(path);
        return response.StatusCode switch
        {
            HttpStatusCode.Unauthorized => throw new UnauthorizedException(),
            HttpStatusCode.Forbidden => throw new ForbiddenException(),
            _ => response
        };
    }

    public async Task<T> GetAsResultAsync<T>(string path) where T : class
    {
        var result = await GetAsync(path);
        if (result.StatusCode == HttpStatusCode.NoContent)
        {
            return null;
        }
        return await result?.Content?.ReadFromJsonAsync<T>();
    }

    public async Task<ResponseDto> PostToResponseDtoAsync<T>(string path, T t) where T : class
        => await ToResponseDto(await disciplineAppClient.PostAsync(path, t));

    public async Task<ResponseDto> PutToResponseDtoAsync<T>(string path, T t) where T : class
        => await ToResponseDto(await disciplineAppClient.PutAsync(path, t));

    public async Task<ResponseDto> PatchToResponseDtoAsync(string path)
        => await ToResponseDto(await disciplineAppClient.PatchAsync(path));

    public async Task<ResponseDto> DeleteToResponseDtoAsync(string path)
        => await ToResponseDto(await disciplineAppClient.DeleteAsync(path));
    
    private static async Task<ResponseDto> ToResponseDto(HttpResponseMessage response)
        => response.StatusCode switch
        {
            HttpStatusCode.Unauthorized => throw new UnauthorizedException(),
            HttpStatusCode.Forbidden => throw new ForbiddenException(),
            _ => response.StatusCode switch
            {
                HttpStatusCode.OK or HttpStatusCode.Created => ResponseDto.GetValid(),
                HttpStatusCode.BadRequest or HttpStatusCode.UnprocessableEntity => ResponseDto.GetInvalid(
                    (await response.Content.ReadFromJsonAsync<ErrorResponseDto>()).Message),
                _ => ResponseDto.GetInvalid()
            }
        };
}