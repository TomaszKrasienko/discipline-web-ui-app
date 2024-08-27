using discipline_wasm_ui.Services.DTOs;
using discipline_wasm_ui.Storage.Abstractions;

namespace discipline_wasm_ui.Auth.Token.Internals;

internal sealed class TokenProvider(
    ILocalStorageAccessor localStorageAccessor) : ITokenProvider
{
    public async Task<string?> GetToken()
    {
        var tokens = await localStorageAccessor.GetItemAsync<TokensDto>();
        return tokens?.Token;
    }
}