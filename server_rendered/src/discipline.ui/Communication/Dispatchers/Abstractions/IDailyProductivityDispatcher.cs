using discipline.ui.Communication.Dispatchers.Models.DailyProductivity;
using discipline.ui.Communication.DTOs;

namespace discipline.ui.Communication.Dispatchers.Abstractions;

public interface IDailyProductivityDispatcher
{
    Task<ResponseDto> CreateTodayActivity(ActivityRequest request);
    Task<ResponseDto> CreateFromActivityRule(ActivityFromRuleRequest request);
    Task<ResponseDto> DeleteActivityAsync(Guid activityId);
    Task<ResponseDto> ChangeActivityCheck(Guid activityId);
    Task<DailyProductivityDto> GetDailyProductivityByDay(DateOnly day);
    Task<IEnumerable<ProgressDataDto>> GetProgressData();
}