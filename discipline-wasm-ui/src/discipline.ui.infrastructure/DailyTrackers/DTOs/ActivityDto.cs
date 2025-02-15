namespace discipline.ui.infrastructure.DailyTrackers.DTOs;

public sealed class ActivityDto
{
    public string ActivityId { get; private set; }
    public string DailyTrackerId { get; private set; }
    public string Title { get; private set; }
    public string? Note { get; private set; }
    public bool IsChecked { get; private set; }

    public ActivityDto(string activityId, string dailyTrackerId, string title, string? note, bool isChecked)
    {
        ActivityId = activityId;
        DailyTrackerId = dailyTrackerId;
        Title = title;
        Note = note;
        IsChecked = isChecked;
    }
    
    public void ChangeCheck()
        => IsChecked = !IsChecked;
}