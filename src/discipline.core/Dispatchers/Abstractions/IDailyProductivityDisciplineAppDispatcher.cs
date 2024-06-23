using discipline.core.Dispatchers.Models.DailyProductivity;
using discipline.core.DTOs;

namespace discipline.core.Dispatchers.Abstractions;

public interface IDailyProductivityDisciplineAppDispatcher
{
    Task<ResponseDto> CreateTodayActivity(ActivityRequest request);
    Task<DailyProductivityDto> GetDailyProductivityByDay(DateOnly day);
}