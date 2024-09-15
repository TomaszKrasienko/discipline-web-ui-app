using discipline_wasm_ui.Infrastructure.Services.Client.Abstractions;
using discipline_wasm_ui.Infrastructure.Services.DTOs;
using discipline_wasm_ui.Infrastructure.Services.Models.UserCalendar;

namespace discipline_wasm_ui.Infrastructure.Services.Dispatchers.Internals;

internal sealed class UserCalendarDispatcher(
    IDisciplineClientFacade disciplineClientFacade) : IUserCalendarDispatcher
{
    public async Task<UserCalendarDto> GetUserCalendarByDayAsync(DateOnly day)
        => await disciplineClientFacade.GetAsResultAsync<UserCalendarDto>($"user-calendar/{day:yyyy-MM-dd}");

    public async Task<ResponseDto> AddImportantDateAsync(ImportantDateRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync("/user-calendar/add-important-date", request,
            "Important date event added");

    public async Task<ResponseDto> AddCalendarEventAsync(CalendarEventRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync("/user-calendar/add-calendar-event", request,
            "Calendar event added");

    public async Task<ResponseDto> AddMeetingAsync(MeetingRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync("/user-calendar/add-meeting", request,
            "Meeting added");
}