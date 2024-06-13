namespace discipline.core.Dispatchers.Models.ActivityRule;

public sealed class CreateActivityRuleRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Mode { get; set; }
    public List<int> SelectedDays { get; set; }
}