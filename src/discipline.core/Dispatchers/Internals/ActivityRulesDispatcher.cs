using System.Net.Http.Json;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Communication.HttpClients.Facades;
using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Models;
using discipline.core.Dispatchers.Models.ActivityRule;
using discipline.core.DTOs;
using discipline.core.Helpers.Abstractions;
using Newtonsoft.Json;

namespace discipline.core.Dispatchers.Internals;

internal sealed class ActivityRulesDispatcher(
    IWeekdayTranslator weekdayTranslator,
    IDisciplineClientFacade disciplineClientFacade) : IActivityRulesDispatcher
{
    public async Task<ResponseDto> CreateActivityRuleAsync(ActivityRuleRequest request)
        => await disciplineClientFacade.PostToResponseDtoAsync("/activity-rules/create", request);

    public async Task<ResponseDto> EditActivityRuleAsync(Guid activityRuleId, ActivityRuleRequest request)
        => await disciplineClientFacade.PutToResponseDtoAsync($"/activity-rules/{activityRuleId}/edit", request);

    public async Task<ResponseDto> DeleteActivityRuleAsync(Guid activityRuleId)
        => await disciplineClientFacade.DeleteToResponseDtoAsync($"/activity-rules/{activityRuleId}/delete");

    public async Task<ActivityRuleDto> GetCreateActivityRuleByIdAsync(Guid activityRuleId)
        => await disciplineClientFacade.GetAsResultAsync<ActivityRuleDto>($"activity-rules/{activityRuleId}");
     
    public async Task<PaginatedDataDto<List<ActivityRuleDto>>> BrowseActivityRules(PaginationRequest request)
    {
        var response = await disciplineClientFacade.GetAsync(
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
        => await disciplineClientFacade.GetAsResultAsync<List<ActivityRuleModeDto>>("activity-rule-modes");
}