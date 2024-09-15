using System.Security.Claims;
using System.Text.Json;
using discipline_wasm_ui.Infrastructure.Auth.Token;
using Microsoft.AspNetCore.Components.Authorization;

namespace discipline_wasm_ui.Infrastructure.Auth;

internal sealed class CustomAuthenticationStateProvider(
    ITokenProvider tokenProvider) : AuthenticationStateProvider 
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await tokenProvider.GetTokenAsync();
        var identity = string.IsNullOrWhiteSpace(token)
            ? new ClaimsIdentity()
            : new ClaimsIdentity(ParseClaimsFromJwt(token), "authentication");
        var user = new ClaimsPrincipal(identity);
        return new AuthenticationState(user);
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}