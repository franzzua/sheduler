using Microsoft.Extensions.DependencyInjection;
using Sheduler.App;
using Sheduler.Contracts.Contracts;
using Sheduler.Domain.Services;

namespace Sheduler.Tests.Mocks;

public class MockDelayedExecutor(IServiceProvider serviceProvider) : IDelayedExecutor
{
    public Dictionary<string, DateTime> ExecutionTimes { get; } = new();
    
    public Task<string> Invoke(TimeSpan delay, string timetableId)
    {
        ExecutionTimes[timetableId] = DateTime.UtcNow.Add(delay);
        return Task.FromResult(timetableId);
    }

    public Task Cancel(string token)
    {
        ExecutionTimes.Remove(token);
        return Task.CompletedTask;
    }

    public void Run(string scheduleId)
    {
        ExecutionTimes.Remove(scheduleId);
        serviceProvider.GetService<AppService>()!.RunSchedule(scheduleId).GetAwaiter().GetResult();
    }
}