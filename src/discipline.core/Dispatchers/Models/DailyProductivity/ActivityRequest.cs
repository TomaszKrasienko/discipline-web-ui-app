namespace discipline.core.Dispatchers.Models.DailyProductivity;

public sealed record ActivityRequest
{
    public string Title { get; set; }
    public DateOnly Day { get; set; }
}