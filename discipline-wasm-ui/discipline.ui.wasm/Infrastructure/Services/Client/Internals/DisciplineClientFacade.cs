using System.Net;
using System.Net.Http.Json;
using discipline_wasm_ui.Infrastructure.Auth.Token;
using discipline_wasm_ui.Infrastructure.Services.Client.Abstractions;
using discipline_wasm_ui.Infrastructure.Services.DTOs;
using discipline_wasm_ui.Services.Models.Users;
using discipline.ui.infrastructure.Auth.Tokens.Abstractions;
using discipline.ui.infrastructure.Auth.Tokens.DTOs;
using Microsoft.AspNetCore.Components;

namespace discipline_wasm_ui.Infrastructure.Services.Client.Internals;

internal sealed class DisciplineResponseFacade(
    IDisciplineClient disciplineAppClient,
    NavigationManager navigationManager,
    ITokenHandler tokenProvider) : IDisciplineClientFacade
{
    public async Task<HttpResponseMessage> GetAsync(string path)
    {
        var response = await disciplineAppClient.GetAsync(path);
        await CheckAuth(response);

        return response;
    }

    public async Task<T> GetAsResultAsync<T>(string path) where T : class
    {
        var result = await GetAsync(path);
        await CheckAuth(result);
        if (result.StatusCode == HttpStatusCode.NoContent)
        {
            return null;
        }
        return await result?.Content?.ReadFromJsonAsync<T>()!;
    }

    public async Task<ResponseDto> PostToResponseDtoAsync<T>(string path, T t, string successMessage = null) where T : class
        => await ToResponseDto(await disciplineAppClient.PostAsync(path, t), successMessage);

    public async Task<ResponseDto> PutToResponseDtoAsync<T>(string path, T t, string successMessage = null) where T : class
        => await ToResponseDto(await disciplineAppClient.PutAsync(path, t), successMessage);

    public async Task<ResponseDto> PatchToResponseDtoAsync(string path, string successMessage = null)
        => await ToResponseDto(await disciplineAppClient.PatchAsync(path), successMessage);

    public async Task<ResponseDto> PatchToResponseDtoAsync<T>(string path, T t, string successMessage = null) where T : class
        => await ToResponseDto(await disciplineAppClient.PatchAsync(path, t), successMessage);

    public async Task<ResponseDto> DeleteToResponseDtoAsync(string path, string successMessage = null)
        => await ToResponseDto(await disciplineAppClient.DeleteAsync(path), successMessage);

    private async Task<ResponseDto> ToResponseDto(HttpResponseMessage response, string successMessage)
    {
        await CheckAuth(response);
        return response.StatusCode switch
        {
            HttpStatusCode.OK or HttpStatusCode.Created => ResponseDto.GetValid(successMessage),
            HttpStatusCode.BadRequest or HttpStatusCode.UnprocessableEntity => ResponseDto.GetInvalid(
                (await response?.Content?.ReadFromJsonAsync<ErrorResponseDto>()!)!.Message!),
            _ => ResponseDto.GetInvalid()
        };
    }

    private async Task CheckAuth(HttpResponseMessage response)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
            {
                if (await TryRefreshToken())
                {
                    break;
                }
                var tcs = new TaskCompletionSource<bool>();
                await tokenProvider.RemoveTokenAsync();
                navigationManager.NavigateTo("/sign-in", forceLoad: true);
                await tcs.Task;
                break;
            }
            case HttpStatusCode.Forbidden:
            {
                var tcs = new TaskCompletionSource<bool>();
                navigationManager.NavigateTo("/pick-subscription-order");
                await tcs.Task;
                break;
            }
        }
    }

    private async Task<bool> TryRefreshToken()
    {
        var refreshToken = await tokenProvider.GetRefreshTokenAsync();
        if (refreshToken is null)
        {
            return false;
        }

        var request = new RefreshTokenRequest()
        {
            RefreshToken = refreshToken
        };
        var response = await disciplineAppClient.PostAsync("/users/refresh-token", request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var tokens = await response.Content.ReadFromJsonAsync<TokensDto>();
            await tokenProvider.SetAsync(tokens);
            return true;
        }

        return false;
    }
}