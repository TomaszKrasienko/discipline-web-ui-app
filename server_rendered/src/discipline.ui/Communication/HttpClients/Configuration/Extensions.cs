using System.Net;
using discipline.ui.Communication.Dispatchers.Abstractions;
using discipline.ui.Communication.HttpClients.Abstractions;
using discipline.ui.Communication.HttpClients.Configuration.Models;
using discipline.ui.Communication.HttpClients.Internals;
using discipline.ui.Configuration;
using Polly;

namespace discipline.ui.Communication.HttpClients.Configuration;

internal static class Extensions
{
    private const string SectionName = "HttpClients";
    
    internal static IServiceCollection AddClients(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<Dictionary<string, HttpClientOptions>>(SectionName);

        if (!options.TryGetValue(nameof(DisciplineAppClient), out var disciplineAppClientOptions)) return services;
        
        var refreshPolicy = Policy.HandleResult<HttpResponseMessage>(x => x.StatusCode is
                HttpStatusCode.Unauthorized)
            .RetryAsync(1, onRetryAsync: async (response, i, context) =>
            {
                var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                var userDispatcher = scope.ServiceProvider.GetRequiredService<IUserDispatcher>();
                await userDispatcher.Refresh();
                
            });

        services.AddHttpClient<IDisciplineAppClient, DisciplineAppClient>(clientOptions =>
            {
                clientOptions.Timeout = disciplineAppClientOptions.Timeout;
                clientOptions.BaseAddress = new Uri(disciplineAppClientOptions.Url);
            })
            .AddPolicyHandler(refreshPolicy);
        
        return services;
    }
}