using System.Net;
using System.Net.Http.Json;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Models;
using discipline.core.Dispatchers.Models.ActivityRule;
using discipline.core.DTOs;
using discipline.core.Helpers.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace discipline.core.Dispatchers.Internals;

internal sealed class ActivityRulesDisciplineAppDispatcher(
    ILogger<ActivityRulesDisciplineAppDispatcher> logger,
    IDisciplineAppClient disciplineAppClient,
    IWeekdayTranslator weekdayTranslator) : IActivityRulesDisciplineAppDispatcher
{
    public async Task<ResponseDto> CreateActivityRuleAsync(ActivityRuleRequest request) 
    {
        var response = await disciplineAppClient.PostAsync("/activity-rules/create", request);
        switch (response.StatusCode)
        {
            case HttpStatusCode.Created:
            {
                return ResponseDto.GetValid();
            }
            case (HttpStatusCode.BadRequest or HttpStatusCode.UnprocessableEntity):
            {
                var errorResult = await response.Content.ReadFromJsonAsync<ErrorResponseDto>();
                return ResponseDto.GetInvalid(errorResult.Message);
            }
            default:
                return ResponseDto.GetInvalid();
        }
    }

    public async Task<ResponseDto> EditActivityRuleAsync(Guid activityRuleId, ActivityRuleRequest request)
    {
        var response = await disciplineAppClient.PutAsync($"/activity-rules/{activityRuleId}/edit", request);
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            {
                return ResponseDto.GetValid();
            }
            case (HttpStatusCode.BadRequest or HttpStatusCode.UnprocessableEntity):
            {
                var errorResult = await response.Content.ReadFromJsonAsync<ErrorResponseDto>();
                return ResponseDto.GetInvalid(errorResult.Message);
            }
            default:
                return ResponseDto.GetInvalid();
        }
    }

    public async Task<ResponseDto> DeleteActivityRuleAsync(Guid activityRuleId)
    {
        var response = await disciplineAppClient.DeleteAsync($"/activity-rules/{activityRuleId}/delete");
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            {
                return ResponseDto.GetValid();
            }
            case (HttpStatusCode.BadRequest):
            {
                var errorResult = await response.Content.ReadFromJsonAsync<ErrorResponseDto>();
                return ResponseDto.GetInvalid(errorResult.Message);
            }
            default:
                return ResponseDto.GetInvalid();
        }
    }

    public async Task<ActivityRuleDto> GetCreateActivityRuleByIdAsync(Guid activityRuleId)
    {
        var response = await disciplineAppClient.GetAsync($"activity-rules/{activityRuleId}");
        if (response.StatusCode is HttpStatusCode.NoContent)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<ActivityRuleDto>();
    }

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
    {
        var response = await disciplineAppClient.GetAsync("activity-rule-modes");
        if (!response.IsSuccessStatusCode)
        {
            logger.LogInformation($"GetActivityRuleModesAsync - status code: {response.StatusCode}");
        }

        return await response.Content.ReadFromJsonAsync<List<ActivityRuleModeDto>>();
    }
}