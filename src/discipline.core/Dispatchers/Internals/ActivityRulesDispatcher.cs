using System.Net.Http.Json;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Models;
using discipline.core.Dispatchers.Models.ActivityRule;
using discipline.core.DTOs;
using discipline.core.Helpers.Abstractions;
using Newtonsoft.Json;

namespace discipline.core.Dispatchers.Internals;

internal sealed class ActivityRulesDispatcher(
    IDisciplineAppClient disciplineAppClient,
    IWeekdayTranslator weekdayTranslator) : IActivityRulesDispatcher
{
    public async Task<ResponseDto> CreateActivityRuleAsync(ActivityRuleRequest request)
        => await (await disciplineAppClient.PostAsync("/activity-rules/create", request)).ToResponseDto();

    public async Task<ResponseDto> EditActivityRuleAsync(Guid activityRuleId, ActivityRuleRequest request)
        => await (await disciplineAppClient.PutAsync($"/activity-rules/{activityRuleId}/edit", request)).ToResponseDto();

    public async Task<ResponseDto> DeleteActivityRuleAsync(Guid activityRuleId)
        => await (await disciplineAppClient.DeleteAsync($"/activity-rules/{activityRuleId}/delete")).ToResponseDto();

    public async Task<ActivityRuleDto> GetCreateActivityRuleByIdAsync(Guid activityRuleId)
        => await (await disciplineAppClient.GetAsync($"activity-rules/{activityRuleId}")).ToResults<ActivityRuleDto>();
     
    public async Task<PaginatedDataDto<List<ActivityRuleDto>>> BrowseActivityRules(PaginationRequest request)
    {
        var response = await disciplineAppClient.GetAsync(
                $"activity-rules?pageNumber={request.PageNumber}&pageSize={request.PageSize}");
        
        var activities = await response.Content.ReadFromJsonAsync<List<ActivityRuleDto>>();
        foreach (var activity in activities)
        {
            activity.Weekdays = weekdayTranslator.Transform(activity.SelectedDays);
        }

        response.Headers.TryGetValues("x-pagination", out var pagination);

        return new PaginatedDataDto<List<ActivityRuleDto>>()
        {
            Data = activities,
            MetaData = JsonConvert.DeserializeObject<MetaDataDto>(pagination!.Single())
        };
    }

    public async Task<List<ActivityRuleModeDto>> GetActivityRuleModesAsync()
        => await (await disciplineAppClient.GetAsync("activity-rule-modes")).ToResults<List<ActivityRuleModeDto>>();
}