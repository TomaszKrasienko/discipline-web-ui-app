using discipline_wasm_ui.Services.DTOs;

namespace discipline_wasm_ui.Helpers.Weekdays.Abstractions;

public interface IWeekdayTranslator
{
    List<WeekdayDto> Transform(List<int> weekdaysIdentifier);
}