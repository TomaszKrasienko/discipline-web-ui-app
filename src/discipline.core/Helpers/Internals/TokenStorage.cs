using discipline.core.Helpers.Abstractions;

namespace discipline.core.Helpers.Internals;

internal sealed class TokenStorage : ITokenStorage
{
    private string _token;

    public void Set(string token)
        => _token = token;

    public string Get()
        => _token;
}