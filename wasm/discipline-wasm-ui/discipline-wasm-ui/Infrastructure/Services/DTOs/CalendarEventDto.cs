namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

public class CalendarEventDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public TimeOnly TimeFrom { get; set; }
    public TimeOnly? TimeTo { get; set; }
    public string Action { get; set; }
}