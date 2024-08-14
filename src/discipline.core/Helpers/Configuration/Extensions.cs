using discipline.core.Communication.HttpClients.Facades;
using discipline.core.Helpers.Abstractions;
using discipline.core.Helpers.Internals;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.core.Helpers.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddHelpers(this IServiceCollection services)
        => services
            .AddSingleton<IWeekdayTranslator, WeekdayTranslator>()
            .AddSingleton<IDisciplineClientFacade, DisciplineResponseFacade>();
}