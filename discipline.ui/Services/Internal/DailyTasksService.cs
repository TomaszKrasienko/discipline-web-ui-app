using discipline.ui.Models;
using discipline.ui.Services.Abstractions;

namespace discipline.ui.Services.Internal;

internal sealed class DailyTasksService : IDailyTasksService
{
    private readonly List<DailyActivity> _dailyTasks =
    [
        new DailyActivity()
        {
            Id = Guid.NewGuid(),
            Sequence = 1,
            Title = "Finish this",
            Checked = false,
            Date = DateTime.Now
        },
        new DailyActivity()
        {
            Id = Guid.NewGuid(),
            Sequence = 2,
            Title = "Make some noise",
            Checked = false,
            Date = DateTime.Now
        },
        new DailyActivity()
        {
            Id = Guid.NewGuid(),
            Sequence = 1,
            Title = "Finish this",
            Checked = false,
            Date = DateTime.Now.AddDays(-1)
        },
        new DailyActivity()
        {
            Id = Guid.NewGuid(),
            Sequence = 2,
            Title = "Make some noise",
            Checked = false,
            Date = DateTime.Now.AddDays(-1)
        }
    ];

    public List<DailyActivity> GetDailyTasks()
        => _dailyTasks;

    public void Update(DailyActivity task)
    {
    }
}