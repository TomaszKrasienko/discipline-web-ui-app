using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Models.UserCalendar;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Internals;

internal sealed class UserCalendarDispatcher(
    IDisciplineAppClient disciplineAppClient) : IUserCalendarDispatcher
{
    public async Task<UserCalendarDto> GetUserCalendarByDayAsync(DateOnly day)
        => await (await disciplineAppClient.GetAsync($"user-calendar/{day:yyyy-MM-dd}"))
            .ToResults<UserCalendarDto>();

    public async Task<ResponseDto> AddImportantDateAsync(ImportantDateRequest request)
        => await (await disciplineAppClient.PostAsync("/user-calendar/add-important-date", request)).ToResponseDto();

    public async Task<ResponseDto> AddCalendarEventAsync(CalendarEventRequest request)
        => await (await disciplineAppClient.PostAsync("/user-calendar/add-calendar-event", request)).ToResponseDto();

    public async Task<ResponseDto> AddMeetingAsync(MeetingRequest request)
        => await (await disciplineAppClient.PostAsync("/user-calendar/add-meeting", request)).ToResponseDto();
}