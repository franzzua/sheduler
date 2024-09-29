using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Contracts.Contracts;
using Sheduler.Storage.Db;
using Sheduler.Storage.Db.Gen;

namespace Sheduler.Storage;

public static class DependencyExtensions
{
    private const string StorageConnectionString = "StorageConnectionString";
    public static IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration[StorageConnectionString] ??
                               throw new ArgumentException($"{StorageConnectionString} is not provided");

        services.AddDbContext<ScheduleContext>(o =>
        {
            o.UseModel(ScheduleContextModel.Instance)
                .UseNpgsql(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        services.AddScoped<IScheduleStorage, ScheduleStorage>();
        return services;
    }
}