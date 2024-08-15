using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Facades;
using discipline.core.Dispatchers.Models.DailyProductivity;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Internals;

internal sealed class DailyProductivityDispatcher(
    IDisciplineClientFacade disciplineClientFacade) : IDailyProductivityDispatcher
{
    public async Task<ResponseDto> CreateTodayActivity(ActivityRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync($"/daily-productivity/{request.Day:yyyy-MM-dd}/add-activity", request);

    public async Task<ResponseDto> CreateFromActivityRule(ActivityFromRuleRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync($"/daily-productivity/today/add-activity-from-rule", request);

    public async Task<ResponseDto> DeleteActivityAsync(Guid activityId)
        => await disciplineClientFacade.DeleteToResponseDtoAsync($"/daily-productivity/activity/{activityId}");

    public async Task<ResponseDto> ChangeActivityCheck(Guid activityId)
        => await disciplineClientFacade.PatchToResponseDtoAsync($"/daily-productivity/activity/{activityId}/change-check");

    public async Task<DailyProductivityDto> GetDailyProductivityByDay(DateOnly day)
        => await disciplineClientFacade.GetAsResultAsync<DailyProductivityDto>($"daily-productivity/{day:yyyy-MM-dd}");

    public async Task<IEnumerable<ProgressDataDto>> GetProgressData()
        => await disciplineClientFacade.GetAsResultAsync<IEnumerable<ProgressDataDto>>("progress/data");
}