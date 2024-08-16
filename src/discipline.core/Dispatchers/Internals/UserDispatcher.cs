using System.Net;
using System.Net.Http.Json;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Facades;
using discipline.core.Dispatchers.Models.Users;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Internals;

internal sealed class UserDispatcher(
    IDisciplineClientFacade disciplineClientFacade,
    IDisciplineAppClient disciplineAppClient) : IUserDispatcher
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

        var result = await response.Content.ReadFromJsonAsync<TokenDto>();
        return ResponseDto.GetValid(result.Token);
    }
}