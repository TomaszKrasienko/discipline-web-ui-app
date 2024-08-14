using System.Net;
using System.Net.Http.Json;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.DTOs;

namespace discipline.core.Communication.HttpClients.Facades;

internal sealed class DisciplineResponseFacade(
    IDisciplineAppClient disciplineAppClient) : IDisciplineClientFacade
{
    public async Task<ResponseDto> ToResponseDto(HttpResponseMessage response)
    {
        var statusCode = response.StatusCode;

        if (statusCode == HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException();
        }

        return statusCode switch
        {
            HttpStatusCode.OK or HttpStatusCode.Created
                => ResponseDto.GetValid(),
            HttpStatusCode.BadRequest or HttpStatusCode.UnprocessableEntity 
                => ResponseDto.GetInvalid((await response.Content.ReadFromJsonAsync<ErrorResponseDto>()).Message),
            _
                => ResponseDto.GetInvalid()
        }; 
    }

    public async Task<T> ToResult<T>(HttpResponseMessage httpResponseMessage) where T : class
    {
        if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException();
        }
        
        return httpResponseMessage.StatusCode is HttpStatusCode.NoContent
            ? null
            : await httpResponseMessage.Content.ReadFromJsonAsync<T>();
    }

    public Task<HttpResponseMessage> GetAsync(string path)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetAsResultAsync<T>(string path)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto> PostToResponseDtoAsync<T>(string path, T t) where T : class
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto> PutToResponseDtoAsync<T>(string path, T t) where T : class
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto> PatchToResponseDtoAsync(string path)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto> DeleteToResponseDtoAsync(string path)
    {
        throw new NotImplementedException();
    }
}