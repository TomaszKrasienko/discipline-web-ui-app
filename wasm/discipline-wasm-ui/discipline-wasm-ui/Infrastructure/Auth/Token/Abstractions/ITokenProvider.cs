namespace discipline_wasm_ui.Infrastructure.Auth.Token;

internal interface ITokenProvider
{
    Task<string> GetToken();
    Task RemoveToken();
}