namespace discipline.ui.infrastructure.DailyTrackers.DTOs;

public sealed class ActivityDto
{
    private readonly HashSet<StageDto>? _stages;
    public string ActivityId { get; private set; }
    public string DailyTrackerId { get; private set; }
    public string Title { get; private set; }
    public string? Note { get; private set; }
    public bool IsChecked { get; private set; }
    public IReadOnlyCollection<StageDto>? Stages => _stages?.ToArray(); 

    private ActivityDto(string activityId, string dailyTrackerId, string title, string? note, bool isChecked,
        IEnumerable<StageDto>? stages)
    {
        ActivityId = activityId;
        DailyTrackerId = dailyTrackerId;
        Title = title;
        Note = note;
        IsChecked = isChecked;

        if (stages is not null)
        {
            _stages = new HashSet<StageDto>(stages);
        }
    }
    
    public static ActivityDto Create(string activityId, string dailyTrackerId, string title, string? note, bool isChecked,
        IEnumerable<StageDto>? stages)
        => new (activityId, dailyTrackerId, title, note, isChecked, stages);
    
    public void ChangeCheck()
        => IsChecked = !IsChecked;

    public void ChangeStageCheck(string stageId)
    {
        var stage = _stages?.Single(x => x.StageId == stageId);
        stage?.ChangeCheck();
    }

    public void ChangeIndeks(string stageId, int newIndex)
    {
        var changed = false;
        var index = 1;
        foreach (var stage in _stages)
        {
            if (stage.StageId == stageId || changed)
            {
                stage.ChangeIndex(index);
                changed = true;
            }

            index++;
        }
    }
}