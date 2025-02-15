namespace discipline.ui.infrastructure.DailyTrackers.DTOs;

public class DailyTrackerDto
{
    private readonly HashSet<ActivityDto> _activities = [];
    
    public DateOnly Day { get; private set; }
    public IReadOnlyCollection<ActivityDto> Activities => _activities.ToArray();

    public DailyTrackerDto(DateOnly day, IEnumerable<ActivityDto> activities)
    {
        Day = day;
        _activities = new HashSet<ActivityDto>(activities);
    }
}