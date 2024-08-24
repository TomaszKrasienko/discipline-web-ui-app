using discipline.ui.Communication.Dispatchers.Abstractions;
using discipline.ui.Communication.Dispatchers.Facades;
using discipline.ui.Communication.Dispatchers.Models;
using discipline.ui.Communication.Dispatchers.Models.ActivityRule;
using discipline.ui.Communication.DTOs;
using discipline.ui.Communication.Helpers.Abstractions;
using Newtonsoft.Json;

namespace discipline.ui.Communication.Dispatchers.Internals;

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