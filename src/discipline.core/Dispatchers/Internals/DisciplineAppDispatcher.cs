using System.Net;
using System.Net.Http.Json;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Models.ActivityRule;
using discipline.core.DTOs;
using Microsoft.Extensions.Logging;

namespace discipline.core.Dispatchers.Internals;

internal sealed class DisciplineAppDispatcher(
    ILogger<DisciplineAppDispatcher> logger,
    IDisciplineAppClient disciplineAppClient) : IDisciplineAppDispatcher
{
    public async Task CreateActivityRuleAsync(CreateActivityRuleRequest request)
    {
        var response = await disciplineAppClient.PostAsync("/activity-rule/create", request);
        if (response.StatusCode is not HttpStatusCode.OK)
        {
            logger.LogInformation($"HttpStatusCode: {response.StatusCode}");
        }
    }

    public Task<ActivityRuleDto> GetByIdAsync(Guid activityRuleId)
    {
        throw new NotImplementedException();
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