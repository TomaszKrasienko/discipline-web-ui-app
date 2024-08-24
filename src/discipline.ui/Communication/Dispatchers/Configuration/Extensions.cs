using discipline.ui.Communication.Dispatchers.Abstractions;
using discipline.ui.Communication.Dispatchers.Facades;
using discipline.ui.Communication.Dispatchers.Internals;

namespace discipline.ui.Communication.Dispatchers.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddDispatchers(this IServiceCollection services)
        => services
            .AddScoped<IActivityRulesDispatcher, ActivityRulesDispatcher>()
            .AddScoped<IDailyProductivityDispatcher, DailyProductivityDispatcher>()
            .AddScoped<IUserCalendarDispatcher, UserCalendarDispatcher>()
            .AddScoped<IUserDispatcher, UserDispatcher>()
            .AddScoped<IDisciplineClientFacade, DisciplineResponseFacade>();
}