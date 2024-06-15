using discipline.core.DTOs;

namespace discipline.core.Helpers.Statics;

public static class AsCheckedWeekdaysStringExtensions
{
    public static string AsCheckedWeekdaysString(this ActivityRuleDto dto)
        => dto?.Weekdays is null || dto?.Weekdays.Count == 0
            ? string.Empty
            : string.Join(", ", dto?.Weekdays?.Where(x
                => x.IsChecked).Select(x => x.Name)!);
}