using discipline_wasm_ui.Infrastructure.Services.Models;
using discipline_wasm_ui.Infrastructure.Services.Models.ActivityRules;

namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

internal interface IActivityRulesDispatcher
{
    Task<ResponseDto> CreateActivityRuleAsync(ActivityRuleRequest request);
    Task<ResponseDto> EditActivityRuleAsync(Guid activityRuleId, ActivityRuleRequest request);
    Task<ResponseDto> DeleteActivityRuleAsync(Guid activityRuleId);
    Task<ActivityRuleDto> GetCreateActivityRuleByIdAsync(Guid activityRuleId);
    Task<PaginatedDataDto<List<ActivityRuleDto>>> BrowseActivityRules(PaginationRequest request);
    Task<List<ActivityRuleModeDto>> GetActivityRuleModesAsync();
}