using System.Net;
using System.Net.Http.Json;
using discipline_wasm_ui.Infrastructure.Services.Client.Abstractions;
using discipline_wasm_ui.Infrastructure.Services.DTOs;
using Microsoft.AspNetCore.Components;

namespace discipline_wasm_ui.Infrastructure.Services.Client.Internals;

internal sealed class DisciplineResponseFacade(
    IDisciplineClient disciplineAppClient,
    NavigationManager navigationManager) : IDisciplineClientFacade
{
    public async Task<HttpResponseMessage> GetAsync(string path)
    {
        var response = await disciplineAppClient.GetAsync(path);

        switch (response.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
                var tcs = new TaskCompletionSource<bool>();
                navigationManager.NavigateTo("/sign-in");
                await tcs.Task;
                break;
        }

        return response;
    }

    public async Task<T> GetAsResultAsync<T>(string path) where T : class
    {
        var result = await GetAsync(path);
        if (result.StatusCode == HttpStatusCode.NoContent)
        {
            return null;
        }
        return await result?.Content?.ReadFromJsonAsync<T>()!;
    }

    public async Task<ResponseDto> PostToResponseDtoAsync<T>(string path, T t) where T : class
        => await ToResponseDto(await disciplineAppClient.PostAsync(path, t));

    public async Task<ResponseDto> PutToResponseDtoAsync<T>(string path, T t) where T : class
        => await ToResponseDto(await disciplineAppClient.PutAsync(path, t));

    public async Task<ResponseDto> PatchToResponseDtoAsync(string path)
        => await ToResponseDto(await disciplineAppClient.PatchAsync(path));

    public async Task<ResponseDto> DeleteToResponseDtoAsync(string path)
        => await ToResponseDto(await disciplineAppClient.DeleteAsync(path));

    private async Task<ResponseDto> ToResponseDto(HttpResponseMessage response)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
                var tcs = new TaskCompletionSource<bool>();
                navigationManager.NavigateTo("/sign-in");
                await tcs.Task;
                break;
        }

        return response.StatusCode switch
        {
            HttpStatusCode.OK or HttpStatusCode.Created => ResponseDto.GetValid(),
            HttpStatusCode.BadRequest or HttpStatusCode.UnprocessableEntity => ResponseDto.GetInvalid(
                (await response?.Content?.ReadFromJsonAsync<ErrorResponseDto>()!)!.Message!),
            _ => ResponseDto.GetInvalid()
        };
    }
}