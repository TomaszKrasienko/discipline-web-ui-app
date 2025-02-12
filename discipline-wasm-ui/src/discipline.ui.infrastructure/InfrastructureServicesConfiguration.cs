using discipline.ui.infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.ui.infrastructure;

public static class InfrastructureServicesConfiguration
{
    public static IServiceCollection SetInfrastructureServices(this IServiceCollection services)
        => services
            .SetUsersServices()
            .SetStorageServices()
            .SetAuthServices();
}