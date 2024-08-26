namespace discipline_wasm_ui.Services.Client.Configuration.Models;

public class ClientOptions
{
    //TODO: Moved to more const place
    public string Url { get; init; } = "http://localhost:6001";
    public TimeSpan Timeout { get; init; } = TimeSpan.FromSeconds(15);
}