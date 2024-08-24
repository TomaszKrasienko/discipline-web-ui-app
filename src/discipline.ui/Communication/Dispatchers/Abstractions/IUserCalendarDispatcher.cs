using discipline.ui.Communication.Dispatchers.Models.UserCalendar;
using discipline.ui.Communication.DTOs;

namespace discipline.ui.Communication.Dispatchers.Abstractions;

public interface IUserCalendarDispatcher
{
    Task<UserCalendarDto> GetUserCalendarByDayAsync(DateOnly day);
    Task<ResponseDto> AddImportantDateAsync(ImportantDateRequest request);
    Task<ResponseDto> AddCalendarEventAsync(CalendarEventRequest request);
    Task<ResponseDto> AddMeetingAsync(MeetingRequest request);
}