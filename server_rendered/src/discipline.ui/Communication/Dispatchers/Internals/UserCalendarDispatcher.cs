using discipline.ui.Communication.Dispatchers.Abstractions;
using discipline.ui.Communication.Dispatchers.Facades;
using discipline.ui.Communication.Dispatchers.Models.UserCalendar;
using discipline.ui.Communication.DTOs;

namespace discipline.ui.Communication.Dispatchers.Internals;

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