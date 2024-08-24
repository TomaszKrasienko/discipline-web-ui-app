using discipline.ui.Communication.Helpers.Abstractions;
using discipline.ui.Communication.Helpers.Internals;

namespace discipline.ui.Communication.Helpers.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddHelpers(this IServiceCollection services)
        => services
            .AddSingleton<IWeekdayTranslator, WeekdayTranslator>()
            .AddScoped<ITokenStorage, TokenStorage>()
            .AddCache();

    private static IServiceCollection AddCache(this IServiceCollection services)
        => services
            .AddMemoryCache();
}