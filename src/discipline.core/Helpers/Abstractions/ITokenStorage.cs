namespace discipline.core.Helpers.Abstractions;

public interface ITokenStorage
{
    void Set(string token);
    string Get();
}