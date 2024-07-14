using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Abstractions;

public interface IUserCalendarDispatcher
{
    Task<UserCalendarDto> GetUserCalendarByDayAsync(DateOnly day);
}