using Refit;

namespace discipline.ui.communication.http.ActivityRules;

public interface IActivityRulesHttpService
{
    [Get("/api/activity-rules")]
    public Task<HttpResponseMessage> GetActivityRules(CancellationToken cancellationToken);
}