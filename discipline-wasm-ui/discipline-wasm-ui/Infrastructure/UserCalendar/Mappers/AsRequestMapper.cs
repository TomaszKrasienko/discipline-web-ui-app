using discipline_wasm_ui.Infrastructure.Services.DTOs;
using discipline_wasm_ui.Infrastructure.Services.Models.UserCalendar;

namespace discipline_wasm_ui.Infrastructure.UserCalendar.Mappers;

internal static class AsRequestMapper
{
    internal static ImportantDateRequest AsImportantDateRequest(this EventDto @event)
        => new ImportantDateRequest()
        {
            Day = @event.Day,
            Title = @event.Title
        };

    internal static CalendarEventRequest AsCalendarEventRequest(this EventDto @event)
        => new CalendarEventRequest()
        {
            Day = @event.Day,
            Title = @event.Title,
            TimeFrom = @event.TimeFrom,
            TimeTo = @event.TimeTo,
            Action = @event.Action
        };

    internal static MeetingRequest AsMeetingRequest(this EventDto @event)
        => new MeetingRequest()
        {
            Day = @event.Day,
            Title = @event.Title,
            TimeFrom = @event.TimeFrom,
            TimeTo = @event.TimeTo,
            Platform = @event.Platform,
            Uri = @event.Uri,
            Place = @event.Place
        };
}