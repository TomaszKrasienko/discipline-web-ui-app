using System.Net;
using System.Net.Http.Json;
using discipline_wasm_ui.Infrastructure.Services.Client.Abstractions;
using discipline_wasm_ui.Infrastructure.Services.DTOs;
using discipline_wasm_ui.Services.Models.Users;
using discipline.ui.infrastructure.Auth.Tokens.DTOs;
using discipline.ui.Infrastructure.Communication.DTOs;

namespace discipline_wasm_ui.Infrastructure.Services.Dispatchers.Internals;

internal sealed class DisciplineUserDispatcher(
    IDisciplineClientFacade disciplineClientFacade,
    IDisciplineClient disciplineAppClient) : IUserDispatcher
{
    public async Task<List<SubscriptionDto>> BrowseSubscriptions()
        => await disciplineClientFacade.GetAsResultAsync<List<SubscriptionDto>>("users/subscriptions");

    public async Task<UserDto> BrowseMe()
        => await disciplineClientFacade.GetAsResultAsync<UserDto>("users/me");

    public async Task<ResponseDto> SignUp(SignUpRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync($"users/sign-up", request);

    public async Task<ResponseDto> CreateSubscriptionOrder(CreateSubscriptionOrderRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync($"/users/create-subscription-order", request, 
            "Subscription order created");
}