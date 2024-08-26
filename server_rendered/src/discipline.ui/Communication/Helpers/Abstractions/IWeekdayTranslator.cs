using discipline.ui.Communication.DTOs;

namespace discipline.ui.Communication.Helpers.Abstractions;

public interface IWeekdayTranslator
{
    List<WeekdayDto> Transform(List<int> weekdaysIdentifier);
}