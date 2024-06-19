using discipline.core.DTOs;
using discipline.core.Helpers.Abstractions;

namespace discipline.core.Helpers.Internals;

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