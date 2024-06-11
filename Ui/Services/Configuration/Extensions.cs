using Ui.Services.Abstractions;
using Ui.Services.Internal;

namespace Ui.Services.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddSingleton<IDailyTasksService, DailyTasksService>()
            .AddSingleton<ILaborIntensityService, ProductivityDataService>();
}