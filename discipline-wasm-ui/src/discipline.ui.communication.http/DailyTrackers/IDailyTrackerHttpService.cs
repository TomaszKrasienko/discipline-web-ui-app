using discipline.ui.communication.http.DailyTrackers.Requests;
using Refit;

namespace discipline.ui.communication.http.DailyTrackers;

public interface IDailyTrackerHttpService
{
    [Post("/api/daily-trackers-module/daily-trackers/activities")]
    public Task<HttpResponseMessage> CreateActivityAsync(CreateActivityRequestDto request, CancellationToken cancellationToken);
    
    [Get("/api/daily-trackers-module/daily-trackers/{day}")]
    public Task<HttpResponseMessage> GetDailyTrackerByDayAsync(string day, CancellationToken cancellationToken);
}