using discipline_wasm_ui.Infrastructure.Services.DTOs;

namespace discipline_wasm_ui.Infrastructure.Auth.Token;

internal interface ITokenProvider
{
    Task<string> GetTokenAsync();
    Task<string> GetRefreshTokenAsync();
    Task RemoveTokenAsync();
    Task SetAsync(TokensDto tokensDto);
}