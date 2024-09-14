using discipline_wasm_ui.Services.Models.Users;
using discipline.ui.Infrastructure.Communication.DTOs;

namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

public interface IUserDispatcher
{
    Task<List<SubscriptionDto>> BrowseSubscriptions();
    Task<ResponseDto> SignUp(SignUpRequest request);
    Task<ResponseDto> SignIn(SignInRequest request);
    Task<ResponseDto> CreateSubscriptionOrder(CreateSubscriptionOrderRequest request);
}