namespace discipline.core.DTOs;

public class DailyProductivityDto
{
    public DateOnly Day { get; set; }
    public List<ActivityDto> Activities { get; set; }
}