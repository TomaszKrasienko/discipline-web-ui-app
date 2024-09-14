using discipline_wasm_ui.Infrastructure.Services.Client.Abstractions;
using discipline_wasm_ui.Infrastructure.Services.DTOs;
using discipline_wasm_ui.Infrastructure.Services.Models.ActivityRules;
using discipline_wasm_ui.Infrastructure.Services.Models.DailyProductivity;

namespace discipline_wasm_ui.Infrastructure.Services.Dispatchers.Internals;

internal sealed class DailyProductivityDispatcher(
    IDisciplineClientFacade disciplineClientFacade) : IDailyProductivityDispatcher
{
    public async Task<ResponseDto> CreateActivity(ActivityRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync($"/daily-productivity/{request.Day:yyyy-MM-dd}/add-activity", request,
            "Today's activity created");

    public async Task<ResponseDto> CreateFromActivityRule(ActivityFromRuleRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync($"/daily-productivity/today/add-activity-from-rule", request,
            "Activity from rule created");

    public async Task<ResponseDto> DeleteActivityAsync(Guid activityId)
        => await disciplineClientFacade.DeleteToResponseDtoAsync($"/daily-productivity/activity/{activityId}",
            "Activity deleted");

    public async Task<ResponseDto> ChangeActivityCheck(Guid activityId)
        => await disciplineClientFacade.PatchToResponseDtoAsync($"/daily-productivity/activity/{activityId}/change-check",
            "Activity changed");

    public async Task<DailyProductivityDto> GetDailyProductivityByDay(DateOnly day)
        => await disciplineClientFacade.GetAsResultAsync<DailyProductivityDto>($"daily-productivity/{day:yyyy-MM-dd}");
    
    public async Task<IEnumerable<ProgressDataDto>> GetProgressData()
        => await disciplineClientFacade.GetAsResultAsync<IEnumerable<ProgressDataDto>>("progress/data");

}