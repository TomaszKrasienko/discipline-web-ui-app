using System.Net;
using discipline_wasm_ui.Configuration;
using discipline_wasm_ui.Infrastructure.Services.Client.Abstractions;
using discipline_wasm_ui.Infrastructure.Services.Client.Configuration.Models;
using discipline_wasm_ui.Infrastructure.Services.Client.Internals;
using Polly;

namespace discipline_wasm_ui.Infrastructure.Services.Client.Configuration;

internal static class Extensions
{
    private const string SectionName = "DisciplineApi";
    
    internal static IServiceCollection AddClients(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddHttp(configuration)
            .AddFacades();
    
    private static IServiceCollection AddHttp(this IServiceCollection services, IConfiguration configuration)
    {
        // var refreshPolicy = Policy.HandleResult<HttpResponseMessage>(x => x.StatusCode is
        //         HttpStatusCode.Unauthorized)
        //     .RetryAsync(1, onRetryAsync: async (response, i, context) =>
        //     {
        //         var serviceProvider = services.BuildServiceProvider();
        //         using var scope = serviceProvider.CreateScope();
        //         
        //     });

        var options = configuration.GetOptions<ClientOptions>(SectionName);
        
        services.AddHttpClient<IDisciplineClient, DisciplineClient>(clientOptions =>
        {
            clientOptions.Timeout = options.Timeout;
            clientOptions.BaseAddress = new Uri(options.Url);
        });
            // .AddPolicyHandler(refreshPolicy);
        
        return services;
    }

    private static IServiceCollection AddFacades(this IServiceCollection services)
        => services.AddSingleton<IDisciplineClientFacade, DisciplineResponseFacade>();

}