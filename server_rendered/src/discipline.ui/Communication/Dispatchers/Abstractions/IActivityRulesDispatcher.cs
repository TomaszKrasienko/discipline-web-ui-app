using discipline.ui.Communication.Dispatchers.Models;
using discipline.ui.Communication.Dispatchers.Models.ActivityRule;
using discipline.ui.Communication.DTOs;

namespace discipline.ui.Communication.Dispatchers.Abstractions;

public interface IActivityRulesDispatcher
{
    Task<ResponseDto> CreateActivityRuleAsync(ActivityRuleRequest request);
    Task<ResponseDto> EditActivityRuleAsync(Guid activityRuleId, ActivityRuleRequest request);
    Task<ResponseDto> DeleteActivityRuleAsync(Guid activityRuleId);
    Task<ActivityRuleDto> GetCreateActivityRuleByIdAsync(Guid activityRuleId);
    Task<PaginatedDataDto<List<ActivityRuleDto>>> BrowseActivityRules(PaginationRequest request);
    Task<List<ActivityRuleModeDto>> GetActivityRuleModesAsync();
}