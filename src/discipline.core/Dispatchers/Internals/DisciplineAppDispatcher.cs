using System.Net;
using System.Net.Http.Json;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Models;
using discipline.core.Dispatchers.Models.ActivityRule;
using discipline.core.DTOs;
using Microsoft.Extensions.Logging;

namespace discipline.core.Dispatchers.Internals;

internal sealed class DisciplineAppDispatcher(
    ILogger<DisciplineAppDispatcher> logger,
    IDisciplineAppClient disciplineAppClient) : IDisciplineAppDispatcher
{
    public async Task<ResponseDto> CreateActivityRuleAsync(ActivityRuleRequest request) 
    {
        var response = await disciplineAppClient.PostAsync("/activity-rule/create", request);
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

    public async Task<ActivityRuleDto> GetCreateActivityRuleByIdAsync(Guid activityRuleId)
    {
        var response = await disciplineAppClient.GetAsync($"activity-rule/{activityRuleId}");
        if (response.StatusCode is HttpStatusCode.NoContent)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<ActivityRuleDto>();
    }

    public async Task<List<ActivityRuleDto>> BrowseActivityRules(PaginationRequest request)
    {
        var response =
            await disciplineAppClient.GetAsync(
                $"activity-rules?pageNumber={request.PageNumber}&pageSize={request.PageSize}");
        return await response.Content.ReadFromJsonAsync<List<ActivityRuleDto>>();
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