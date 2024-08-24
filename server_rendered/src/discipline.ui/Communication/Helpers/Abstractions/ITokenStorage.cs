using discipline.ui.Communication.DTOs;

namespace discipline.ui.Communication.Helpers.Abstractions;

public interface ITokenStorage
{
    Task Set(TokensDto tokens);
    Task<TokensDto> Get();
}