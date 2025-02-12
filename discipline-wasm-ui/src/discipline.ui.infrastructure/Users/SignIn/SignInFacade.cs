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
    public async Task<OneOf<bool, string>> SignIn(string email, string password)
    {
        var signInRequest = new SignInRequestDto(email, password);
        
        var signInResponse = await userHttpClient.SignIn(signInRequest);

        if (!signInResponse.IsSuccessStatusCode)
        {
            var response = await signInResponse.Content.ReadFromJsonAsync<ProblemDetails>();
            return response?.Detail ?? "Unknown Error";
        }
        
        var tokens = new TokensDto(email, password);
        await tokenHandler.SetAsync(tokens);
        return true;
    }
}