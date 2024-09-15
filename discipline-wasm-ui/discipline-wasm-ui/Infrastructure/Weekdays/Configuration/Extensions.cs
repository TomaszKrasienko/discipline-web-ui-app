using discipline_wasm_ui.Infrastructure.Weekdays.Abstractions;
using discipline_wasm_ui.Infrastructure.Weekdays.Internals;

namespace discipline_wasm_ui.Infrastructure.Weekdays.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddWeekdays(this IServiceCollection services)
        => services
            .AddSingleton<IWeekdayTranslator, WeekdayTranslator>();
}