using discipline.core.DTOs;

namespace discipline.core.Helpers.Abstractions;

public interface ITokenStorage
{
    void Set(TokensDto tokens);
    TokensDto Get();
}