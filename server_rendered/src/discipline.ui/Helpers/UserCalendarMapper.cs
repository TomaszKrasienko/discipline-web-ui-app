using discipline.ui.Communication.Dispatchers.Models.UserCalendar;
using discipline.ui.Models;

namespace discipline.ui.Helpers;

internal static class UserCalendarMapperExtensions
{
    internal static ImportantDateRequest AsImportantDateRequest(this UserCalendarEvent @event)
        => new ImportantDateRequest()
        {
            Day = @event.Day,
            Title = @event.Title
        };

    internal static CalendarEventRequest AsCalendarEventRequest(this UserCalendarEvent @event)
        => new CalendarEventRequest()
        {
            Day = @event.Day,
            Title = @event.Title,
            TimeFrom = @event.TimeFrom,
            TimeTo = @event.TimeTo,
            Action = @event.Action
        };

    internal static MeetingRequest AsMeetingRequest(this UserCalendarEvent @event)
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