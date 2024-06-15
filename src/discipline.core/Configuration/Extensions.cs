using discipline.core.Communication.HttpClients.Configuration;
using discipline.core.Dispatchers.Configuration;
using discipline.core.Helpers.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.core.Configuration;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddClients(configuration)
            .AddDispatchers()
            .AddHelpers();
    
    internal static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var t = new T();
        configuration.Bind(sectionName, t);
        return t;
    }
}