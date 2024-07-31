using discipline.core.Dispatchers.Models.Users;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Abstractions;

public interface IUserDispatcher
{
    Task<List<SubscriptionDto>> BrowseSubscriptions();
    Task<ResponseDto> SignUp(SignUpRequest request);
}