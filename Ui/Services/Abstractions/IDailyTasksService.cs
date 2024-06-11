using Ui.Models;

namespace Ui.Services.Abstractions;

public interface IDailyTasksService
{
    List<DailyActivity> GetDailyTasks();
    
    void Update(DailyActivity task);
}