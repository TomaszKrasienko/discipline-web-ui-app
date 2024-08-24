using discipline.ui.Enums;

namespace discipline.ui.Dictionaries;

internal static class EventTypeDictionary
{
    internal static Dictionary<EventType, string> Dictionary = new()
    {
        [EventType.CalendarEvent] = "Calendar event",
        [EventType.Meeting] = "Meeting",
        [EventType.ImportantDate] = "Important date"
    };
}