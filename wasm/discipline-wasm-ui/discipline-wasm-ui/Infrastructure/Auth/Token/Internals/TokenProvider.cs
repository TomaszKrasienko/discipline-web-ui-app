using discipline_wasm_ui.Infrastructure.Services.DTOs;
using discipline_wasm_ui.Infrastructure.Storage.Abstractions;

namespace discipline_wasm_ui.Infrastructure.Auth.Token.Internals;

internal sealed class TokenProvider(
    ILocalStorageAccessor localStorageAccessor) : ITokenProvider
{
    public async Task<string> GetToken()
    {
        var tokens = await localStorageAccessor.GetItemAsync<TokensDto>();
        return tokens?.Token;
    }

    public async Task RemoveToken()
        => await localStorageAccessor.RemoveAsync<TokensDto>();
}