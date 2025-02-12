namespace discipline_wasm_ui.Infrastructure.SignalR;

public sealed record SignalROptions
{
    public string Url { get; init; }
    public Dictionary<string, string> Methods { get; set; }
}