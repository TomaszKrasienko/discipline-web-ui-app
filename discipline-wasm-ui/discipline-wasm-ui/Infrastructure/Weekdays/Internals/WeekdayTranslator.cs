using discipline_wasm_ui.Infrastructure.Services.DTOs;
using discipline_wasm_ui.Infrastructure.Weekdays.Abstractions;
using discipline_wasm_ui.Infrastructure.Weekdays.Factories;

namespace discipline_wasm_ui.Infrastructure.Weekdays.Internals;

internal sealed class WeekdayTranslator : IWeekdayTranslator
{
    public List<WeekdayDto> Transform(List<int> weekdaysIdentifier)
    {
        if (weekdaysIdentifier is null) { return WeekdayFactory.Get(); }
        var weekDays = WeekdayFactory.Get();
        weekdaysIdentifier.ForEach(id => weekDays.Single(x => x.Id == id).IsChecked = true);
        return weekDays;
    }
}