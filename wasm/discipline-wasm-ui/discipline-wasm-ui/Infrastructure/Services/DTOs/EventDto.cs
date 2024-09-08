namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

public class EventDto
{
    public DateOnly Day { get; set; }
    public string Title { get; set; }
    public TimeOnly TimeFrom { get; set; }
    public TimeOnly? TimeTo { get; set; }
    public string Action { get; set; }
    public string Platform { get; set; }
    public string Uri { get; set; }
    public string Place { get; set; }
}