using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Domain;
using Sheduler.Storage;
using Sheduler.Timers.GoogleQueue;

namespace Sheduler.App;

public static class DependencyExtensions
{
    public static IServiceCollection AddApp(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDomain();
        services.AddGoogleQueueTimers(configuration);
        services.AddStorage(configuration);
        services.AddScoped<AppService>();
        return services;
    }
}