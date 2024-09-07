namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

public class UserCalendarDto
{
    public DateOnly Day { get; set; }
    public List<ImportantDateDto> ImportantDates { get; set; }
    public List<CalendarEventDto> CalendarEvents { get; set; }
    public List<MeetingDto> Meetings { get; set; }
}