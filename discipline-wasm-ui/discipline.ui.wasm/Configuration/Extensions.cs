using discipline_wasm_ui.Infrastructure.Auth.Token.Configuration;
using discipline_wasm_ui.Infrastructure.Services.Configuration;
using discipline_wasm_ui.Infrastructure.SignalR;
using discipline_wasm_ui.Infrastructure.Storage.Configuration;
using discipline_wasm_ui.Infrastructure.Weekdays.Configuration;
using discipline.ui.communication.http;
using discipline.ui.infrastructure;

namespace discipline_wasm_ui.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        => services
            .SetAuthServices()
            .SetHttpCommunicationServices(configuration)
            .SetInfrastructureServices()
            .AddServices(configuration)
            .AddStorage()
            .AddWeekdays()
            .AddSignalR(configuration);
    
    internal static T GetOptions<T>(this IConfiguration configuration, string section) where T : class, new()
    {
        var t = new T();
        configuration.Bind(section, t);
        return t;
    } 
}