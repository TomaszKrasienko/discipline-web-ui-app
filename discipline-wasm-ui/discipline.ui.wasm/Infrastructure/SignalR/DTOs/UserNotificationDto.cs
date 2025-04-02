namespace discipline_wasm_ui.Infrastructure.SignalR.DTOs;

public sealed record UserNotificationDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}