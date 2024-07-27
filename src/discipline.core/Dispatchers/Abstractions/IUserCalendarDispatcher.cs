using discipline.core.Dispatchers.Models.UserCalendar;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Abstractions;

public interface IUserCalendarDispatcher
{
    Task<UserCalendarDto> GetUserCalendarByDayAsync(DateOnly day);
    Task<ResponseDto> AddImportantDateAsync(ImportantDateRequest request);
    Task<ResponseDto> AddCalendarEventAsync(CalendarEventRequest request);
    Task<ResponseDto> AddMeetingAsync(MeetingRequest request);
}