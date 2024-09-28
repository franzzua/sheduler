using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Contracts.Contracts;

namespace Sheduler.Storage;

public static class DependencyExtensions
{
    private const string StorageConnectionString = "StorageConnectionString";
    public static IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration[StorageConnectionString] ??
                               throw new ArgumentException($"{StorageConnectionString} is not provided");
        services.AddSingleton<IScheduleStorage, ScheduleStorage>(
            s => new ScheduleStorage(connectionString)
        );
        return services;
    }
}