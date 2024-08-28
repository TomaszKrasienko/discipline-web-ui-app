using discipline_wasm_ui.Infrastructure.Services.DTOs;

namespace discipline_wasm_ui.Infrastructure.Weekdays.Abstractions;

public interface IWeekdayTranslator
{
    List<WeekdayDto> Transform(List<int> weekdaysIdentifier);
}