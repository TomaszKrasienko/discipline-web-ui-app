using discipline.ui.infrastructure.Auth.Tokens.DTOs;

namespace discipline.ui.infrastructure.Auth.Tokens.Abstractions;

public interface ITokenHandler
{
    Task<string> GetTokenAsync();
    Task<string> GetRefreshTokenAsync();
    Task RemoveTokenAsync();
    Task SetAsync(TokensDto tokensDto);
}