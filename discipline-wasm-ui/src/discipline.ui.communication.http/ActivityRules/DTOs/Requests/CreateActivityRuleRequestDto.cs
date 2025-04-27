namespace discipline.ui.communication.http.ActivityRules.DTOs.Requests;

public sealed record CreateActivityRuleRequestDto(ActivityRuleDetailsDto Details, 
    string Mode,
    IReadOnlyList<int>? SelectedDays,
    IReadOnlyList<StageRequestDto>? Stages);
