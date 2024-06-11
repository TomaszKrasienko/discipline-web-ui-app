using Ui.Models;

namespace Ui.Services.Abstractions;

public interface ILaborIntensityService
{
    List<DailyProductivity> GetLaborIntensities();
}