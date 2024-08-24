using System.Net;
using System.Net.Http.Json;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Facades;
using discipline.core.Dispatchers.Models.Users;
using discipline.core.DTOs;
using discipline.core.Helpers.Abstractions;

namespace discipline.core.Dispatchers.Internals;

internal sealed class UserDispatcher(
    IDisciplineClientFacade disciplineClientFacade,
    IDisciplineAppClient disciplineAppClient,
    ITokenStorage tokenStorage) : IUserDispatcher
{
    public async Task<List<SubscriptionDto>> BrowseSubscriptions()
        => await disciplineClientFacade.GetAsResultAsync<List<SubscriptionDto>>("users/subscriptions");

    public async Task<ResponseDto> SignUp(SignUpRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync($"users/sign-up", request);

    public async Task<ResponseDto> SignIn(SignInRequest request)
    {
        var response = await disciplineAppClient.PostAsync("users/sign-in", request);
        if (response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.UnprocessableEntity)
        {
            var invalidResult = await response.Content.ReadFromJsonAsync<ErrorResponseDto>();
            return ResponseDto.GetInvalid(invalidResult.Message);
        }

        var result = await response.Content.ReadFromJsonAsync<TokensDto>();
        return ResponseDto.GetValid(result);
    }

    public async Task<ResponseDto> Refresh()
    {
        var tokens = tokenStorage.Get();
        if (tokens is null || string.IsNullOrWhiteSpace(tokens.RefreshToken))
        {
            return null;
        }

        var request = new RefreshTokenRequest()
        {
            RefreshToken = tokens.RefreshToken
        };
        var response = await disciplineAppClient.PostAsync("users/refresh-token", request);
        if (response.StatusCode is HttpStatusCode.OK)
        {
            var refreshedTokens = await response.Content.ReadFromJsonAsync<TokensDto>();
            tokenStorage.Set(refreshedTokens);
            return ResponseDto.GetValid();
        }
        return ResponseDto.GetInvalid();
    }

    public async Task<ResponseDto> CreateSubscriptionOrder(CreateSubscriptionOrderRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync($"/users/create-subscription-order", request);
}