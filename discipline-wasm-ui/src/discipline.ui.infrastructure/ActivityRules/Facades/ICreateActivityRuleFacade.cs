using System.Net;
using System.Net.Http.Json;
using discipline.ui.communication.http.ActivityRules;
using discipline.ui.communication.http.ActivityRules.DTOs.Requests;
using OneOf;
using Refit;

namespace discipline.ui.infrastructure.ActivityRules.Facades;

public interface ICreateActivityRuleFacade
{
    Task<OneOf<bool, string>> HandleAsync(CreateActivityRuleRequestDto request, CancellationToken cancellationToken);
}

internal sealed class CreateActivityRuleFacade(
    IActivityRulesHttpService activityRulesHttpService) : ICreateActivityRuleFacade
{
    public async Task<OneOf<bool, string>> HandleAsync(CreateActivityRuleRequestDto request, CancellationToken cancellationToken)
    {
        var response = await activityRulesHttpService.CreateActivityRule(request, cancellationToken);
        
        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return "user.unauthorized";
            }
            
            var error = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);

            return error?.Title ?? "system.unexpectedError";
        }

        return true;
    }
}