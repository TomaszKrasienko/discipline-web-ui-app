using System.Net.Http.Json;
using discipline.ui.communication.http.Users;
using discipline.ui.communication.http.Users.Requests;
using discipline.ui.infrastructure.Auth.Tokens.Abstractions;
using discipline.ui.infrastructure.Auth.Tokens.DTOs;
using OneOf;
using Refit;

namespace discipline.ui.infrastructure.Users.SignIn;

internal sealed class SignInFacade(
    IUserHttpClient userHttpClient,
    ITokenHandler tokenHandler) : ISignInFacade
{
    public async Task<OneOf<bool, string>> SignIn(string email, string password, CancellationToken cancellationToken)
    {
        var signInRequest = new SignInRequestDto(email, password);

        HttpResponseMessage signInResponse;
        try
        {
            signInResponse = await userHttpClient.SignIn(signInRequest);

            if (!signInResponse.IsSuccessStatusCode)
            {
                var response = await signInResponse.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
                return response?.Detail ?? "Unknown Error";
            }
        }
        catch (Exception )
        {
            return "Server communication error";
        }

        var tokens = new TokensDto(email, password);
        await tokenHandler.SetAsync(tokens);
        return true;
    }
}