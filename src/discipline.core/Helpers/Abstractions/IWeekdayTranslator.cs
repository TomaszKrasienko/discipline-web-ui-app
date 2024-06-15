using discipline.core.DTOs;

namespace discipline.core.Helpers.Abstractions;

public interface IWeekdayTranslator
{
    List<WeekdayDto> Transform(List<int> weekdaysIdentifier);
}