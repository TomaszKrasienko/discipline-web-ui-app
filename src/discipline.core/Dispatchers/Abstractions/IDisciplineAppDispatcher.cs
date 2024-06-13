using discipline.core.Dispatchers.Models.ActivityRule;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Abstractions;

public interface IDisciplineAppDispatcher
{
    Task CreateActivityRuleAsync(CreateActivityRuleRequest request);
    Task<ActivityRuleDto> GetByIdAsync(Guid activityRuleId);
}