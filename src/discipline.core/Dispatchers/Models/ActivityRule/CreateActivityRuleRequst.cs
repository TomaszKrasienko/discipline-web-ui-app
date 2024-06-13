namespace discipline.core.Dispatchers.Models.ActivityRule;

public sealed record CreateActivityRuleRequest(Guid Id, string Title, string Mode, List<int> SelectedDays);