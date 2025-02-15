using discipline.ui.infrastructure.DailyTrackers.Activities;
using discipline.ui.infrastructure.DailyTrackers.DailyTrackers;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

internal static class DailyTrackersConfigurationExtensions
{
    internal static IServiceCollection SetDailyTrackersServices(this IServiceCollection services)
        => services
            .AddTransient<ICreateActivityFacade, CreateActivityFacade>()
            .AddTransient<IChangeActivityCheckFacade, ChangeActivityCheckFacade>()
            .AddTransient<IDeleteActivityFacade, DeleteActivityFacade>()
            .AddTransient<IBrowseDailyTrackerFacade, BrowseDailyTrackerFacade>();
}