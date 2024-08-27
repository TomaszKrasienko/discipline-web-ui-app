using discipline_wasm_ui.Helpers.Weekdays.Abstractions;
using discipline_wasm_ui.Helpers.Weekdays.Internals;

namespace discipline_wasm_ui.Helpers.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddHelpers(this IServiceCollection services)
        => services
            .AddSingleton<IWeekdayTranslator, WeekdayTranslator>();
}