using discipline.core.Dispatchers.Models.ActivityRule;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Abstractions;

public interface IDisciplineAppDispatcher
{
    Task<ResponseDto> CreateActivityRuleAsync(CreateActivityRuleRequest request);
    Task<ActivityRuleDto> GetByIdAsync(Guid activityRuleId);
    Task<List<ActivityRuleModeDto>> GetActivityRuleModesAsync();
}