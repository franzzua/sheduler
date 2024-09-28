using Microsoft.Extensions.DependencyInjection;
using Sheduler.App;
using Sheduler.Contracts.Contracts;
using Sheduler.Domain.Services;

namespace Sheduler.Tests.Mocks;

public class MockDelayedExecutor(IServiceProvider serviceProvider) : IDelayedExecutor
{
    public Dictionary<string, DateTime> ExecutionTimes { get; } = new();
    
    public async Task<string> Invoke(TimeSpan delay, string timetableId)
    {
        ExecutionTimes[timetableId] = DateTime.UtcNow.Add(delay);
        return timetableId;
    }

    public async Task Cancel(string token)
    {
        ExecutionTimes.Remove(token);
    }

    public void Run(string scheduleId)
    {
        ExecutionTimes.Remove(scheduleId);
        serviceProvider.GetService<AppService>()!.RunSchedule(scheduleId).GetAwaiter().GetResult();
    }
}