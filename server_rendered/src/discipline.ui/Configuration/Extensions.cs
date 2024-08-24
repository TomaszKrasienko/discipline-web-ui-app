using discipline.ui.Communication.Dispatchers.Configuration;
using discipline.ui.Communication.Helpers.Configuration;
using discipline.ui.Communication.HttpClients.Configuration;

namespace discipline.ui.Configuration;

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