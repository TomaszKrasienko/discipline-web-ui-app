using discipline.ui.communication.http.DailyTrackers;
using OneOf;

namespace discipline.ui.infrastructure.DailyTrackers.Activities;

public interface IChangeActivityCheckFacade
{
    Task<OneOf<bool, string>> HandleAsync(string dailyTrackerId, string activityId,
        CancellationToken cancellationToken);
}

internal sealed class ChangeActivityCheckFacade(
    IDailyTrackerHttpService dailyTrackerHttpService) : IChangeActivityCheckFacade
{
    public async Task<OneOf<bool, string>> HandleAsync(string dailyTrackerId, string activityId, CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken);
        return true;
    }
}