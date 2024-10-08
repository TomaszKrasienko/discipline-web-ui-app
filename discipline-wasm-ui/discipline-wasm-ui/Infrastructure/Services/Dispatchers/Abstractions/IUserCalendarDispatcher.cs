using discipline_wasm_ui.Infrastructure.Services.Models.UserCalendar;

namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

public interface IUserCalendarDispatcher
{
    Task<UserCalendarDto> GetUserCalendarByDayAsync(DateOnly day);
    Task<ResponseDto> AddImportantDateAsync(ImportantDateRequest request);
    Task<ResponseDto> AddCalendarEventAsync(CalendarEventRequest request);
    Task<ResponseDto> AddMeetingAsync(MeetingRequest request);
}