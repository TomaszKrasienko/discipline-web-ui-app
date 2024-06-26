using discipline.core.Dispatchers.Models;
using discipline.core.Dispatchers.Models.ActivityRule;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Abstractions;

public interface IActivityRulesDispatcher
{
    Task<ResponseDto> CreateActivityRuleAsync(ActivityRuleRequest request);
    Task<ResponseDto> EditActivityRuleAsync(Guid activityRuleId, ActivityRuleRequest request);
    Task<ResponseDto> DeleteActivityRuleAsync(Guid activityRuleId);
    Task<ActivityRuleDto> GetCreateActivityRuleByIdAsync(Guid activityRuleId);
    Task<PaginatedDataDto<List<ActivityRuleDto>>> BrowseActivityRules(PaginationRequest request);
    Task<List<ActivityRuleModeDto>> GetActivityRuleModesAsync();
}