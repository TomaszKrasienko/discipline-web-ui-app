using discipline.core.DTOs;
using discipline.core.Helpers.Abstractions;

namespace discipline.core.Helpers.Internals;

internal sealed class TokenStorage : ITokenStorage
{
    private TokensDto _tokens;

    public void Set(TokensDto tokens)
        => _tokens = tokens;

    public TokensDto Get()
        => _tokens;
}