using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Facades;
using discipline.core.Dispatchers.Models.Users;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Internals;

internal sealed class UserDispatcher(
    IDisciplineClientFacade disciplineClientFacade) : IUserDispatcher
{
    public async Task<List<SubscriptionDto>> BrowseSubscriptions()
        => await disciplineClientFacade.GetAsResultAsync<List<SubscriptionDto>>("users/subscriptions");

    public async Task<ResponseDto> SignUp(SignUpRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync($"users/sign-up", request);
}