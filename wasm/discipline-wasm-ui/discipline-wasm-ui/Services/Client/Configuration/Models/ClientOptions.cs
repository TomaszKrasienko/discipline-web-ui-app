namespace discipline_wasm_ui.Services.Client.Configuration.Models;

public class ClientOptions
{
    public string Url { get; init; } = string.Empty;
    public int Retries { get; init; }
    public TimeSpan WaitDuration { get; init; }
    public TimeSpan Timeout { get; init; } = TimeSpan.FromSeconds(15);
}