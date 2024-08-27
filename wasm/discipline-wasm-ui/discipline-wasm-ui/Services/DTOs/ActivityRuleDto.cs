namespace discipline_wasm_ui.Services.DTOs;

public class ActivityRuleDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Mode { get; set; }
    public List<int> SelectedDays { get; set; }
    public List<WeekdayDto> Weekdays { get; set; }
}