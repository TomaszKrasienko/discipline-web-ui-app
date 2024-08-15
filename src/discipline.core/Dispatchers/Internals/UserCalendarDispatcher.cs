using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Facades;
using discipline.core.Dispatchers.Models.UserCalendar;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Internals;

internal sealed class UserCalendarDispatcher(
    IDisciplineClientFacade disciplineClientFacade) : IUserCalendarDispatcher
{
    public async Task<UserCalendarDto> GetUserCalendarByDayAsync(DateOnly day)
        => await disciplineClientFacade.GetAsResultAsync<UserCalendarDto>($"user-calendar/{day:yyyy-MM-dd}");

    public async Task<ResponseDto> AddImportantDateAsync(ImportantDateRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync("/user-calendar/add-important-date", request);

    public async Task<ResponseDto> AddCalendarEventAsync(CalendarEventRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync("/user-calendar/add-calendar-event", request);

    public async Task<ResponseDto> AddMeetingAsync(MeetingRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync("/user-calendar/add-meeting", request);
}