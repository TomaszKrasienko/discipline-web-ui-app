using System.Globalization;
using Ui.Models;
using Ui.Services.Abstractions;

namespace Ui.Services.Internal;

internal sealed class ProductivityDataService : ILaborIntensityService
{
    private readonly List<DailyProductivity> _laborIntensities =
    [
        new DailyProductivity()
        {
            Day = DateTime.Today.AddDays(-1).Date.ToString("dd/MM/yyyy"),
            Percent = 90
        },
        new DailyProductivity()
        {
            Day = DateTime.Today.AddDays(-2).Date.ToString("dd/MM/yyyy"),
            Percent = 60
        },
        new DailyProductivity()
        {
            Day = DateTime.Today.AddDays(-3).Date.ToString("dd/MM/yyyy"),
            Percent = 80
        },
        new DailyProductivity()
        {
            Day = DateTime.Today.AddDays(-4).Date.ToString("dd/MM/yyyy"),
            Percent = 70
        }
    ];

    public List<DailyProductivity> GetLaborIntensities()
        => _laborIntensities;
}