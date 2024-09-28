using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Contracts.Contracts;

namespace Sheduler.Timers.GoogleQueue;

public static class DependencyExtensions
{
    private const string QueueName = "QueueName";
    private const string PublicUrl = "PublicUrl";
    public static IServiceCollection AddGoogleQueueTimers(this IServiceCollection services, IConfiguration configuration)
    {
        var queueName = configuration[QueueName] ??
                        throw new ArgumentException($"{QueueName} is not provided");
        var publicUrl = configuration[PublicUrl] ??
                        throw new ArgumentException($"{PublicUrl} is not provided");
        
        services.AddSingleton<IDelayedExecutor, GoogleTaskExecutor>(
            s => new GoogleTaskExecutor(queueName, publicUrl)
        );
        return services;
    }
}