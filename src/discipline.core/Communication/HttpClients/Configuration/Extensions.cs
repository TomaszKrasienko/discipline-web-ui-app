using System.Net;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Communication.HttpClients.Configuration.Models;
using discipline.core.Communication.HttpClients.Internals;
using discipline.core.Configuration;
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

        if (options.TryGetValue(nameof(DisciplineAppClient), out var disciplineAppClientOptions))
        {
            var policy = Policy.HandleResult<HttpResponseMessage>(x => !x.IsSuccessStatusCode && x.StatusCode is not (HttpStatusCode.BadRequest or HttpStatusCode.UnprocessableEntity))
                .WaitAndRetryAsync(disciplineAppClientOptions.Retries, attempts => attempts * disciplineAppClientOptions.WaitDuration);
            
            services.AddHttpClient<IDisciplineAppClient, DisciplineAppClient>(options =>
            {
                options.Timeout = disciplineAppClientOptions.Timeout;
                options.BaseAddress = new Uri(disciplineAppClientOptions.Url);
            }).AddPolicyHandler(policy);
        }
        return services;
    }
}