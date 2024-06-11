namespace Ui.Models;

public class DailyActivity
{
    public Guid Id { get; set; }
    public int Sequence { get; set; }
    public string? Title { get; set; }
    public bool Checked { get; set; }
    public DateTime Date { get; set; }
}