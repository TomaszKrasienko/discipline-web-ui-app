using OneOf;

namespace discipline.ui.infrastructure.Users.SignIn;

public interface ISignInFacade
{
    Task<OneOf<bool, string>> SignIn(string email, string password, CancellationToken cancellationToken);
}