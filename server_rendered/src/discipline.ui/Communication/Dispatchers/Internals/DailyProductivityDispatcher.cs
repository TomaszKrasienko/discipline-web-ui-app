using discipline.ui.Communication.Dispatchers.Abstractions;
using discipline.ui.Communication.Dispatchers.Facades;
using discipline.ui.Communication.Dispatchers.Models.DailyProductivity;
using discipline.ui.Communication.DTOs;

namespace discipline.ui.Communication.Dispatchers.Internals;

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