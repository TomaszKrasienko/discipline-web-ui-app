using discipline.core.Dispatchers.Models.ActivityRule;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Abstractions;

public interface IDisciplineAppDispatcher
{
    Task<ResponseDto> CreateActivityRuleAsync(ActivityRuleRequest request);
    Task<ActivityRuleDto> GetCreateActivityRuleByIdAsync(Guid activityRuleId);
    Task<List<ActivityRuleModeDto>> GetActivityRuleModesAsync();
}