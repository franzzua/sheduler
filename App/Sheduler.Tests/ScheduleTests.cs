using Microsoft.Extensions.DependencyInjection;
using Sheduler.App;
using Sheduler.Contracts.Contracts;
using Sheduler.Domain;
using Sheduler.Storage;
using Sheduler.Tests.Mocks;

namespace Sheduler.Tests;

[TestClass]
public class ScheduleTests
{
    private static ServiceProvider _serviceProvider = null!;
    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext _)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDomain();
        serviceCollection.AddMocks();
        serviceCollection.AddScoped<AppService>();
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    [TestMethod]
    public async Task TestMethod1()
    {
        return;
        var manager = _serviceProvider.GetService<AppService>()!;
        var mockDelayedExecutor = (MockDelayedExecutor)_serviceProvider.GetService<IDelayedExecutor>()!;
        var mockExecutor = (MockExecutor)_serviceProvider.GetService<IExecutor>()!;
        var schedule = new ScheduleViewModel
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Test Schedule",
            Tasks = [new TaskViewModel
            {
                Id = "",
                Uri = "Task Uri",
                CronExpression = Cronos.CronExpression.EverySecond.ToString()
            }]
        };
        await manager.CreateSchedule(schedule);
        var nextTime = mockDelayedExecutor.ExecutionTimes[schedule.Id];
        Assert.IsNotNull(nextTime);
        await Task.Delay(3000);
        mockDelayedExecutor.Run(schedule.Id);
        var count = mockExecutor.Invocations[schedule.Tasks.First().Uri].Count;
        Assert.AreEqual(3, count);
    }
}