using System.Net;
using discipline_wasm_ui.Services.Client.Abstractions;
using discipline_wasm_ui.Services.Client.Internals;
using Polly;

namespace discipline_wasm_ui.Services.Client.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddClients(this IServiceCollection services, IConfiguration configuration)
    {
        var refreshPolicy = Policy.HandleResult<HttpResponseMessage>(x => x.StatusCode is
                HttpStatusCode.Unauthorized)
            .RetryAsync(1, onRetryAsync: async (response, i, context) =>
            {
                var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                //todo: dokończyć
                //var userDispatcher = scope.ServiceProvider.GetRequiredService<IUserDispatcher>();
                //await userDispatcher.Refresh();
                
            });

        services.AddHttpClient<IDisciplineClient, DisciplineClient>(clientOptions =>
            {
                clientOptions.Timeout = disciplineAppClientOptions.Timeout;
                clientOptions.BaseAddress = new Uri(disciplineAppClientOptions.Url);
            })
            .AddPolicyHandler(refreshPolicy);
        
        return services;
    }
}