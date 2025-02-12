namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

public class ActivityDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsChecked { get; set; }
    public Guid? ParentRuleId { get; set; }
}