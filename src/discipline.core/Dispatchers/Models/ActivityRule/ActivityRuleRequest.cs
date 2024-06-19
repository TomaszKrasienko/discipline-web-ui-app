namespace discipline.core.Dispatchers.Models.ActivityRule;

public sealed class ActivityRuleRequest
{
    public string Title { get; set; }
    public string Mode { get; set; }
    public List<int> SelectedDays { get; set; }
}