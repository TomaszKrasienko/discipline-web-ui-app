namespace discipline.ui.communication.http.ActivityRules.DTOs.Requests;

public sealed record CreateActivityRuleRequestDto
{
    public required string Title { get; init; }
    public string? Note { get; init; }
    public required string Mode { get; init; }
    public IReadOnlyList<int>? SelectedDays { get; init; }
    public IReadOnlyList<StageRequestDto>? Stages { get; init; }
}