namespace discipline.ui.Models;

public class NewActivity
{
    public string Title { get; set; } = string.Empty;
    public string Mode { get; set; } = string.Empty;
    public List<string>? SelectedDays { get; set; }
}