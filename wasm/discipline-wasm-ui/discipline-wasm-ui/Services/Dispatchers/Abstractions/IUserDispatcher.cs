using discipline_wasm_ui.Services.Models.Users;
using discipline.ui.Communication.DTOs;

namespace discipline_wasm_ui.Services.DTOs;

public interface IUserDispatcher
{
    Task<List<SubscriptionDto>> BrowseSubscriptions();
    Task<ResponseDto> SignUp(SignUpRequest request);
    Task<ResponseDto> SignIn(SignInRequest request);
    Task<ResponseDto> Refresh();
    Task<ResponseDto> CreateSubscriptionOrder(CreateSubscriptionOrderRequest request);
}