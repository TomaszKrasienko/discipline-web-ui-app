namespace discipline_wasm_ui.Services.Models.ActivityRules;

public class ActivityRuleRequest
{
    public string Title { get; set; }
    public string Mode { get; set; }
    public List<int> SelectedDays { get; set; }
}