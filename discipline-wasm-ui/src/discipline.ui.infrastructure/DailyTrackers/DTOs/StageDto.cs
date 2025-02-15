namespace discipline.ui.infrastructure.DailyTrackers.DTOs;

public sealed class StageDto
{
    public string StageId { get; }
    public string Title { get; }
    public int Index { get; private set; }
    public bool IsChecked { get; private set; }

    private StageDto(string stageId, string title, int index, bool isChecked)
    {
        StageId = stageId;
        Title = title;
        Index = index;
        IsChecked = isChecked;
    }
    
    public static StageDto Create(string stageId, string title, int index, bool isChecked)
        => new(stageId, title, index, isChecked);
    
    public void ChangeCheck()
        => IsChecked = !IsChecked;
    
    public void ChangeIndex(int newIndex)
        => Index = newIndex;
}
