using discipline.core.Dispatchers.Models.DailyProductivity;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Abstractions;

public interface IDailyProductivityDispatcher
{
    Task<ResponseDto> CreateTodayActivity(ActivityRequest request);
    Task<ResponseDto> CreateFromActivityRule(ActivityFromRuleRequest request);
    Task<ResponseDto> DeleteActivityAsync(Guid activityId);
    Task<ResponseDto> ChangeActivityCheck(Guid activityId);
    Task<DailyProductivityDto> GetDailyProductivityByDay(DateOnly day);
    Task<List<ProgressDataDto>> GetProgressDate();
}