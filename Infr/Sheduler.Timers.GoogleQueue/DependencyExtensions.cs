using Google.Cloud.Tasks.V2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Contracts.Contracts;

namespace Sheduler.Timers.GoogleQueue;

public static class DependencyExtensions
{
    private const string QueueSection = "Queue";
    private const string PublicUrl = "PublicUrl";
    public static IServiceCollection AddGoogleQueueTimers(this IServiceCollection services, IConfiguration configuration)
    {
        var queueSection = configuration.GetSection(QueueSection) ??
                        throw new ArgumentException($"Section {QueueSection} is not provided");
        var publicUrl = configuration[PublicUrl] ??
                        throw new ArgumentException($"{PublicUrl} is not provided");
        
        services.AddSingleton<IDelayedExecutor, GoogleTaskExecutor>(
            s => new GoogleTaskExecutor(
                new QueueName(queueSection["ProjectId"], queueSection["Location"], queueSection["Name"])
                , publicUrl)
        );
        return services;
    }
}