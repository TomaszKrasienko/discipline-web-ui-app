namespace discipline_wasm_ui.Infrastructure.Services.Models.DailyProductivity;

public class ActivityRequest
{
    public string Title { get; set; }
    public DateOnly Day { get; set; }
}