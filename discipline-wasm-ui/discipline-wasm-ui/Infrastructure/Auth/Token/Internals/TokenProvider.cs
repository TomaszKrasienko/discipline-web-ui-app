using discipline_wasm_ui.Infrastructure.Services.DTOs;
using discipline_wasm_ui.Infrastructure.Storage.Abstractions;

namespace discipline_wasm_ui.Infrastructure.Auth.Token.Internals;

internal sealed class TokenProvider(
    ILocalStorageAccessor localStorageAccessor) : ITokenProvider
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