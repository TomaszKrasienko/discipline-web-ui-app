using discipline_wasm_ui.Infrastructure.UserCalendar.Enums;

namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

public class UserCalendarEventIdentifierDto
{
    public EventType Type { get; set; }
    public Guid Id { get; set; }
}