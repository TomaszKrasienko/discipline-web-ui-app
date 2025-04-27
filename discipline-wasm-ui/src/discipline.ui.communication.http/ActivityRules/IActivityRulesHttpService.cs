using discipline.ui.communication.http.ActivityRules.DTOs.Requests;
using discipline.ui.communication.http.DailyTrackers.Requests;
using Refit;

namespace discipline.ui.communication.http.ActivityRules;

public interface IActivityRulesHttpService
{
    [Get("/api/activity-rules")]
    public Task<HttpResponseMessage> GetActivityRules(CancellationToken cancellationToken);
    
    [Get("/api/activity-rules/modes")]
    public Task<HttpResponseMessage> GetModesAsync(CancellationToken cancellationToken);
    
    [Delete("/api/activity-rules/{id}")]
    public Task<HttpResponseMessage> DeleteActivityRule(string id, CancellationToken cancellationToken);
    
    [Post("/api/activity-rules")]
    public Task<HttpResponseMessage> CreateActivityRule(CreateActivityRuleRequestDto request, CancellationToken cancellationToken);
}