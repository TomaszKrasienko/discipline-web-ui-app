using discipline.ui.Models;

namespace discipline.ui.Services.Abstractions;

public interface ILaborIntensityService
{
    List<DailyProductivity> GetLaborIntensities();
}