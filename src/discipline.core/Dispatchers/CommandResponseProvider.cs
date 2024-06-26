using System.Net;
using System.Net.Http.Json;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers;

internal static class CommandResponseProvider
{
    internal static async Task<ResponseDto> ToResponseDto(this HttpResponseMessage response)
    {
        var statusCode = response.StatusCode;
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

    internal static async Task<T> ToResults<T>(this HttpResponseMessage response) where T : class
        => response.StatusCode is HttpStatusCode.NoContent
            ? null
            : await response.Content.ReadFromJsonAsync<T>();

}