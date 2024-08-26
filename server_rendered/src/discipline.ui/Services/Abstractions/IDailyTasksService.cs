using discipline.ui.Models;

namespace discipline.ui.Services.Abstractions;

public interface IDailyTasksService
{
    List<DailyActivity> GetDailyTasks();
    
    void Update(DailyActivity task);
}