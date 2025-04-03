namespace discipline.ui.communication.http.ActivityRules.DTOs.Responses;

public sealed record ActivityRuleStageResponseDto
{
    public required string StageId { get; set; }
    public required string Title { get; set; }
    public int Index { get; set; }
}