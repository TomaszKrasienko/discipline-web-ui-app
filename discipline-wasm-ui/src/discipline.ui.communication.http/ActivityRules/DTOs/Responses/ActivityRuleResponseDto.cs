namespace discipline.ui.communication.http.ActivityRules.DTOs.Responses;

public sealed record ActivityRuleResponseDto
{
    public required string ActivityRuleId { get; set; }
    public required string Title { get; set; }
    public required string Note { get; set; }
    public required string Mode { get; set; }
    public IReadOnlyCollection<int>? SelectedDays { get; set; }
    public required List<ActivityRuleStageResponseDto> Stages { get; set; }
}