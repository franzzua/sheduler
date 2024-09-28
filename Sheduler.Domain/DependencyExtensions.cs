using Microsoft.Extensions.DependencyInjection;
using Sheduler.Contracts.Contracts;
using Sheduler.Domain.Services;

namespace Sheduler.Domain;

public static class DependencyExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<IExecutor, ExecutorService>();
        services.AddSingleton<ITaskService, TaskService>();
        return services;
    }
}