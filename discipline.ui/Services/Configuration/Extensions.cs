using discipline.ui.Services.Abstractions;
using discipline.ui.Services.Internal;

namespace discipline.ui.Services.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddSingleton<IDailyTasksService, DailyTasksService>()
            .AddSingleton<ILaborIntensityService, ProductivityDataService>();
}