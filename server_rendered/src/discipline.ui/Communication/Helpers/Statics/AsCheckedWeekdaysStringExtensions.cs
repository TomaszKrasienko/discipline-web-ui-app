using discipline.ui.Communication.DTOs;

namespace discipline.ui.Communication.Helpers.Statics;

public static class AsCheckedWeekdaysStringExtensions
{
    public static string AsCheckedWeekdaysString(this ActivityRuleDto dto, string separator = null)
        => dto?.Weekdays is null || dto?.Weekdays.Count == 0
            ? string.Empty
            : $"{separator ?? string.Empty} {string.Join(", ", dto?.Weekdays?.Where(x
                => x.IsChecked).Select(x => x.Name)!)}";
}