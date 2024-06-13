using discipline.core.Communication.HttpClients.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.core.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        => services.AddClients(configuration);
    
    internal static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var t = new T();
        configuration.Bind(sectionName, t);
        return t;
    }
}