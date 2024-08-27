using discipline_wasm_ui.Services.DTOs;

namespace discipline_wasm_ui.Helpers;

internal static class AsCheckedWeekdaysStringExtensions
{
    public static string AsCheckedWeekdaysString(this ActivityRuleDto dto, string separator = null)
        => dto?.Weekdays is null || dto?.Weekdays.Count == 0
            ? string.Empty
            : $"{separator ?? string.Empty} {string.Join(", ", dto?.Weekdays?.Where(x
                => x.IsChecked).Select(x => x.Name)!)}";
}