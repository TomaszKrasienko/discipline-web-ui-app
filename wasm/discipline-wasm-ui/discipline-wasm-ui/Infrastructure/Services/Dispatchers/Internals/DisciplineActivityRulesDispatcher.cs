using System.Net.Http.Json;
using discipline_wasm_ui.Infrastructure.Services.Client.Abstractions;
using discipline_wasm_ui.Infrastructure.Services.DTOs;
using discipline_wasm_ui.Infrastructure.Services.Models;
using discipline_wasm_ui.Infrastructure.Services.Models.ActivityRules;
using discipline_wasm_ui.Infrastructure.Weekdays.Abstractions;
using Newtonsoft.Json;

namespace discipline_wasm_ui.Infrastructure.Services.Dispatchers.Internals;

internal sealed class DisciplineActivityRulesDispatcher(
    IDisciplineClientFacade disciplineClientFacade,
    IWeekdayTranslator weekdayTranslator) : IActivityRulesDispatcher
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

        var activities = await response?.Content?.ReadFromJsonAsync<List<ActivityRuleDto>>();
        foreach (var activity in activities)
        {
            activity.Weekdays = weekdayTranslator.Transform(activity.SelectedDays);
        }

        var metaData = new MetaDataDto();
        if (response?.Headers.TryGetValues("x-pagination", out var pagination) ?? false)
        {
            metaData = JsonConvert.DeserializeObject<MetaDataDto>(pagination!.Single());
        };
        return new PaginatedDataDto<List<ActivityRuleDto>>()
        {
            Data = activities,
            MetaData = metaData
        };
    }

    public async Task<List<ActivityRuleModeDto>> GetActivityRuleModesAsync()
        => await disciplineClientFacade.GetAsResultAsync<List<ActivityRuleModeDto>>("activity-rule-modes");
}