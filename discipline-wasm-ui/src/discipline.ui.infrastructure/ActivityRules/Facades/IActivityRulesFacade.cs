using System.Net;
using System.Net.Http.Json;
using discipline.ui.communication.http.ActivityRules;
using discipline.ui.communication.http.ActivityRules.DTOs.Responses;
using Microsoft.AspNetCore.Components;

namespace discipline.ui.infrastructure.ActivityRules.Facades;

public interface IActivityRulesBrowseFacade
{
    Task<IReadOnlyList<ActivityRuleResponseDto>> HandleAsync(CancellationToken cancellationToken);
}

internal sealed class ActivityRulesBrowseFacade(
    IActivityRulesHttpService activityRulesHttpService,
    NavigationManager navigationManager) : IActivityRulesBrowseFacade
{
    public async Task<IReadOnlyList<ActivityRuleResponseDto>> HandleAsync(CancellationToken cancellationToken)
    {
        var response = await activityRulesHttpService.GetActivityRules(cancellationToken);
        
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            navigationManager.NavigateTo("/sign-in");
        }
        
        return await response.Content.ReadFromJsonAsync<IReadOnlyList<ActivityRuleResponseDto>>(cancellationToken)
            ?? [];
    }
}