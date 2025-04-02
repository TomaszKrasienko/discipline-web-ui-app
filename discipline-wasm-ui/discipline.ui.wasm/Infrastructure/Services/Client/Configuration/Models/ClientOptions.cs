namespace discipline_wasm_ui.Infrastructure.Services.Client.Configuration.Models;

public sealed record ClientOptions
{
    public string Url { get; init; }
    public TimeSpan Timeout { get; init; }
}