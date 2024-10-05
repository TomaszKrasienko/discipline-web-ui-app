using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;

namespace discipline_wasm_ui.Infrastructure.SignalR;

internal static class Extensions
{
    private const string SectionName = "SignalR";
    
    internal static IServiceCollection AddSignalR(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddOptions(configuration)
            .AddClient();

    private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        => services.Configure<SignalROptions>(configuration.GetSection(SectionName));

    private static IServiceCollection AddClient(this IServiceCollection services)
        => services.AddSingleton(sp =>
        {
            var options = sp.GetRequiredService<IOptions<SignalROptions>>()?.Value;
            return new HubConnectionBuilder()
                .WithUrl(options?.Url ?? string.Empty)
                .WithAutomaticReconnect()
                .Build();
        });
}