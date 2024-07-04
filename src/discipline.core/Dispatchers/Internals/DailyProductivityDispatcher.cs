using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Models.DailyProductivity;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Internals;

internal sealed class DailyProductivityDispatcher(
    IDisciplineAppClient disciplineAppClient) : IDailyProductivityDispatcher
{
    public async Task<ResponseDto> CreateTodayActivity(ActivityRequest request)
        => await (await disciplineAppClient.PostAsync(
            $"/daily-productivity/{request.Day:yyyy-MM-dd}/add-activity", request)).ToResponseDto();

    public async Task<ResponseDto> CreateFromActivityRule(ActivityFromRuleRequest request)
        => await (await disciplineAppClient.PostAsync(
            $"/daily-productivity/today/add-activity-from-rule", request)).ToResponseDto();

    public async Task<ResponseDto> DeleteActivityAsync(Guid activityId)
        => await (await disciplineAppClient.DeleteAsync(
            $"/daily-productivity/activity/{activityId}")).ToResponseDto();

    public async Task<ResponseDto> ChangeActivityCheck(Guid activityId)
        => await (await disciplineAppClient.PatchAsync(
            $"/daily-productivity/activity/{activityId}/change-check")).ToResponseDto();

    public async Task<DailyProductivityDto> GetDailyProductivityByDay(DateOnly day)
        => await (await disciplineAppClient.GetAsync($"daily-productivity/{day:yyyy-MM-dd}"))
            .ToResults<DailyProductivityDto>();

    public async Task<List<ProgressDataDto>> GetProgressDate()
        => await (await disciplineAppClient.GetAsync("/progress/data"))
            .ToResults<List<ProgressDataDto>>();
}