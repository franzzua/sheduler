using Microsoft.Extensions.DependencyInjection;
using Sheduler.Contracts.Contracts;

namespace Sheduler.Tests.Mocks;

public static class DependencyExtensions
{
    public static IServiceCollection AddMocks(this IServiceCollection services)
    {
        services.AddSingleton<IScheduleStorage, MockScheduleStorage>();
        services.AddSingleton<IDelayedExecutor, MockDelayedExecutor>();
        services.AddSingleton<IExecutor, MockExecutor>();
        return services;
    }
}