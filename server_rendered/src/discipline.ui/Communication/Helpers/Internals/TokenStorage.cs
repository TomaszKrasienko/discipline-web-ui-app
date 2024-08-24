using discipline.ui.Communication.DTOs;
using discipline.ui.Communication.Helpers.Abstractions;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace discipline.ui.Communication.Helpers.Internals;

internal sealed class TokenStorage(
    ProtectedSessionStorage protectedSessionStorage) : ITokenStorage
{
    public async Task Set(TokensDto tokens)
        => await protectedSessionStorage.SetAsync("tokens", tokens);
    
    public async Task<TokensDto> Get()
    {
        var tokens = await protectedSessionStorage.GetAsync<TokensDto>("tokens");
        if (!tokens.Success)
        {
            return null;
        }
        return new TokensDto()
        {
            RefreshToken = tokens.Value!.RefreshToken,
            Token = tokens.Value.Token
        };
    }
}