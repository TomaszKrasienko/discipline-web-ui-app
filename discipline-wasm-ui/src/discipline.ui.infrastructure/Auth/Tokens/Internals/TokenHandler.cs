using discipline.ui.infrastructure.Auth.Tokens.Abstractions;
using discipline.ui.infrastructure.Auth.Tokens.DTOs;
using discipline.ui.infrastructure.Storage.Abstractions;

namespace discipline.ui.infrastructure.Auth.Tokens.Internals;

internal sealed class TokenHandler(
    ILocalStorageAccessor localStorageAccessor) : ITokenHandler
{
    public async Task<string> GetTokenAsync()
    {
        var tokens = await localStorageAccessor.GetItemAsync<TokensDto>();
        return tokens?.Token;
    }

    public async Task<string> GetRefreshTokenAsync()
    {
        var tokens = await localStorageAccessor.GetItemAsync<TokensDto>();
        return tokens?.RefreshToken;
    }

    public async Task RemoveTokenAsync()
        => await localStorageAccessor.RemoveAsync<TokensDto>();

    public async Task SetAsync(TokensDto tokensDto)
    {
        await localStorageAccessor.RemoveAsync<TokensDto>();
        await localStorageAccessor.SetItemAsync(tokensDto);
    }
}