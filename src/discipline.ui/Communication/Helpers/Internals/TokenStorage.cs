using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using discipline.ui.Communication.DTOs;
using discipline.ui.Communication.Helpers.Abstractions;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Extensions.Caching.Memory;

namespace discipline.ui.Communication.Helpers.Internals;

internal sealed class TokenStorage(
    IMemoryCache memoryCache,
    ProtectedSessionStorage protectedSessionStorage) : ITokenStorage
{
    private string _token;
    private readonly JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();

    public async Task Set(TokensDto tokens)
    {
        _token = tokens.Token;
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(tokens.Token);
        var userId = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        memoryCache.Set(userId, tokens.RefreshToken);
        await protectedSessionStorage.SetAsync("tokens", tokens);
    } 
    public async Task<TokensDto> Get()
    {
        if (_token is null)
        {
            return null;
        }

        var token = _tokenHandler.ReadJwtToken(_token);
        var userId = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var refreshToken = memoryCache.Get<string>(userId);
        await protectedSessionStorage.GetAsync<TokensDto>("tokens");
        return new TokensDto()
        {
            RefreshToken = refreshToken,
            Token = _token
        };
    }
}