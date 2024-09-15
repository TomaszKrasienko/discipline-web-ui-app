using discipline_wasm_ui.Infrastructure.Auth.Configuration;
using discipline_wasm_ui.Infrastructure.Services.Configuration;
using discipline_wasm_ui.Infrastructure.Storage.Configuration;
using discipline_wasm_ui.Infrastructure.Weekdays.Configuration;

namespace discipline_wasm_ui.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddServices(configuration)
            .AddStorage()
            .AddAuth()
            .AddWeekdays();

    internal static T GetOptions<T>(this IConfiguration configuration, string section) where T : class, new()
    {
        var t = new T();
        configuration.Bind(section, t);
        return t;
    } 
}