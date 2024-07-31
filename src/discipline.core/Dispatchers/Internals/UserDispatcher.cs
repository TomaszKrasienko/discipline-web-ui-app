using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Models.Users;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Internals;

internal sealed class UserDispatcher(
    IDisciplineAppClient disciplineAppClient) : IUserDispatcher
{
    public async Task<List<SubscriptionDto>> BrowseSubscriptions()
        => await (await disciplineAppClient.GetAsync("users/subscriptions"))
            .ToResults<List<SubscriptionDto>>();

    public async Task<ResponseDto> SignUp(SignUpRequest request)
        => await (await disciplineAppClient.PostAsync($"users/sign-up", request)).ToResponseDto();
}