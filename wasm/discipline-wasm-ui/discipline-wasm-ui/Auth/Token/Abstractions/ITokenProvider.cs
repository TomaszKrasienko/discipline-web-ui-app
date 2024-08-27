namespace discipline_wasm_ui.Auth.Token;

internal interface ITokenProvider
{
    Task<string?> GetToken();
}