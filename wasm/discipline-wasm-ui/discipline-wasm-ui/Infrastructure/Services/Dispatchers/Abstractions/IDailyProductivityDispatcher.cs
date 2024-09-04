using discipline_wasm_ui.Infrastructure.Services.Models.ActivityRules;
using discipline_wasm_ui.Infrastructure.Services.Models.DailyProductivity;

namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

public interface IDailyProductivityDispatcher
{
    Task<ResponseDto> CreateActivity(ActivityRequest request);
    Task<ResponseDto> CreateFromActivityRule(ActivityFromRuleRequest request);
    Task<ResponseDto> DeleteActivityAsync(Guid activityId);
    Task<ResponseDto> ChangeActivityCheck(Guid activityId);
    Task<DailyProductivityDto> GetDailyProductivityByDay(DateOnly day);
}