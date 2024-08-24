using System.Net;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Communication.HttpClients.Configuration.Models;
using discipline.core.Communication.HttpClients.Internals;
using discipline.core.Configuration;
using discipline.core.Dispatchers.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace discipline.core.Communication.HttpClients.Configuration;

internal static class Extensions
{
    private const string SectionName = "HttpClients";
    
    internal static IServiceCollection AddClients(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<Dictionary<string, HttpClientOptions>>(SectionName);

        if (!options.TryGetValue(nameof(DisciplineAppClient), out var disciplineAppClientOptions)) return services;
        
        var retryPolicy = Policy.HandleResult<HttpResponseMessage>(x => x.StatusCode is not (
                HttpStatusCode.BadRequest or HttpStatusCode.UnprocessableEntity))
            .WaitAndRetryAsync(disciplineAppClientOptions.Retries, attempts => attempts * disciplineAppClientOptions.WaitDuration);

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
        .AddPolicyHandler(refreshPolicy)
        .AddPolicyHandler(retryPolicy);
        
        return services;
    }
}