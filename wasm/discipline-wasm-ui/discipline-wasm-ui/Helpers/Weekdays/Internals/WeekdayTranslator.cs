using discipline_wasm_ui.Helpers.Weekdays.Abstractions;
using discipline_wasm_ui.Services.DTOs;

namespace discipline_wasm_ui.Helpers.Weekdays.Internals;

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