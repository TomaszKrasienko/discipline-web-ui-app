using discipline.ui.infrastructure.ActivityRules.Facades;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.ui.infrastructure;

public static class InfrastructureServicesConfiguration
{
    public static IServiceCollection SetInfrastructureServices(this IServiceCollection services)
        => services
            .AddTransient<IActivityRulesBrowseFacade, ActivityRulesBrowseFacade>()
            .SetUsersServices()
            .SetDailyTrackersServices()
            .SetStorageServices()
            .SetAuthServices();
}