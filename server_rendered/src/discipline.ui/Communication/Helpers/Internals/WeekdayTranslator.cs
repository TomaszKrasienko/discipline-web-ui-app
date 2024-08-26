using discipline.ui.Communication.DTOs;
using discipline.ui.Communication.Helpers.Abstractions;
using discipline.ui.Communication.Helpers.Statics;

namespace discipline.ui.Communication.Helpers.Internals;

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