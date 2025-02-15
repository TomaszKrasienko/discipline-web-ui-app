namespace discipline.ui.infrastructure.DailyTrackers.DTOs;

public sealed class DailyTrackerDto
{
    private readonly HashSet<ActivityDto> _activities;
    public DateOnly Day { get; private set; }
    public IReadOnlyCollection<ActivityDto> Activities => _activities.ToArray();

    private DailyTrackerDto(DateOnly day, IEnumerable<ActivityDto> activities)
    {
        Day = day;
        _activities = new HashSet<ActivityDto>(activities);
    }
    
    public static DailyTrackerDto Create(DateOnly day, IEnumerable<ActivityDto> activities)
        => new (day, activities);
}