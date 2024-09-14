namespace discipline_wasm_ui.Infrastructure.Services.Models.UserCalendar;

public class CalendarEventRequest
{
    public DateOnly Day { get; set; }
    public string Title { get; set; }
    public TimeOnly TimeFrom { get; set; }
    public TimeOnly? TimeTo { get; set; }
    public string Action { get; set; }
}