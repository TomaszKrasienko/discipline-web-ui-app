using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Dispatchers.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.core.Dispatchers.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddDispatchers(this IServiceCollection services)
        => services
            .AddScoped<IDisciplineAppDispatcher>();
}