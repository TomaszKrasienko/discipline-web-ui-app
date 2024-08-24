namespace discipline.ui.Communication.HttpClients.Configuration.Models;

public sealed record HttpClientOptions
{
    public string Url { get; init; } = string.Empty;
    public int Retries { get; init; }
    public TimeSpan WaitDuration { get; init; }
    public TimeSpan Timeout { get; init; }
}