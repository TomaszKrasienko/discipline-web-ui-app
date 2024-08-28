using System.Net;
using discipline_wasm_ui.Infrastructure.Services.Client.Abstractions;
using discipline_wasm_ui.Infrastructure.Services.Client.Configuration.Models;
using discipline_wasm_ui.Infrastructure.Services.Client.Internals;
using Polly;

namespace discipline_wasm_ui.Infrastructure.Services.Client.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddClients(this IServiceCollection services)
        => services
            .AddHttp()
            .AddFacades();
    
    private static IServiceCollection AddHttp(this IServiceCollection services)
    {
        var refreshPolicy = Policy.HandleResult<HttpResponseMessage>(x => x.StatusCode is
                HttpStatusCode.Unauthorized)
            .RetryAsync(1, onRetryAsync: async (response, i, context) =>
            {
                var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                //TODO: To finish
                //var userDispatcher = scope.ServiceProvider.GetRequiredService<IUserDispatcher>();
                //await userDispatcher.Refresh();
                
            });

        services.AddHttpClient<IDisciplineClient, DisciplineClient>(clientOptions =>
            {
                var disciplineAppClientOptions = new ClientOptions();
                clientOptions.Timeout = disciplineAppClientOptions.Timeout;
                clientOptions.BaseAddress = new Uri(disciplineAppClientOptions.Url);
            })
            .AddPolicyHandler(refreshPolicy);
        
        return services;
    }

    private static IServiceCollection AddFacades(this IServiceCollection services)
        => services.AddSingleton<IDisciplineClientFacade, DisciplineResponseFacade>();

}