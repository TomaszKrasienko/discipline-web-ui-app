using discipline.ui.Communication.Dispatchers.Models.Users;
using discipline.ui.Communication.DTOs;

namespace discipline.ui.Communication.Dispatchers.Abstractions;

public interface IUserDispatcher
{
    Task<List<SubscriptionDto>> BrowseSubscriptions();
    Task<ResponseDto> SignUp(SignUpRequest request);
    Task<ResponseDto> SignIn(SignInRequest request);
    Task<ResponseDto> Refresh();
    Task<ResponseDto> CreateSubscriptionOrder(CreateSubscriptionOrderRequest request);
}