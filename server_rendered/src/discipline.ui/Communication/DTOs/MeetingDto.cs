namespace discipline.ui.Communication.DTOs;

public class MeetingDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public TimeOnly TimeFrom { get; set; }
    public TimeOnly? TimeTo { get; set; }
    public string Platform { get; set; }
    public string Uri { get; set; }
    public string Place { get; set; }
}