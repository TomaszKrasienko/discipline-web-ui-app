using discipline.core.Dispatchers.Models.UserCalendar;
using discipline.ui.Models;

namespace discipline.ui.Helpers;

internal static class UserCalendarMapperExtensions
{
    internal static ImportantDateRequest AsImportantDate(this UserCalendarEvent @event)
        => new ImportantDateRequest()
        {
            Day = @event.Day,
            Title = @event.Title
        };
}