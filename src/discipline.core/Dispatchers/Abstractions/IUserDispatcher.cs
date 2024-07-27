using discipline.core.Dispatchers.Models.Users;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Abstractions;

public interface IUserDispatcher
{
    Task<ResponseDto> SignUp(SignUpRequest request);
}