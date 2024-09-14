namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

public class DailyProductivityDto
{
    public DateOnly Day { get; set; }
    public List<ActivityDto> Activities { get; set; } = [];
}