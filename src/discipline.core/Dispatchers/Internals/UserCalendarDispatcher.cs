using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Dispatchers.Abstractions;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Internals;

internal sealed class UserCalendarDispatcher(
    IDisciplineAppClient disciplineAppClient) : IUserCalendarDispatcher
{
    public async Task<UserCalendarDto> GetUserCalendarByDayAsync(DateOnly day)
        => await (await disciplineAppClient.GetAsync($"user-calendar/{day:yyyy-MM-dd}"))
            .ToResults<UserCalendarDto>();
}