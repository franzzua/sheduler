using Cronos;
using Sheduler.Contracts.Contracts;
using Sheduler.Contracts.Models;

namespace Sheduler.Domain.Services;

internal class TaskService(
    IScheduleStorage scheduleStorage,
    IDelayedExecutor delayedExecutor,
    IExecutor executor
    ) : ITaskService
{
    
    public async Task UpdateTask(Schedule schedule)
    {
        var nextInvocation = await scheduleStorage.GetNextInvocation(schedule); 
        var next = GetNextOccurence(schedule);
        Console.WriteLine($"Now: {DateTime.UtcNow:o}, next: {next:o}");
        if (next == nextInvocation?.Time) return;
        if (nextInvocation != null)
            await delayedExecutor.Cancel(nextInvocation.Id);
        if (next != null)
        {
            var nextTaskId = await delayedExecutor.Invoke(next.Value - DateTime.UtcNow, schedule.Id);
            await scheduleStorage.UpdateNextInvocation(schedule, new TaskInvocation(nextTaskId, next.Value));
        }
    }

    public async Task Run(Schedule schedule)
    {
        foreach (var scheduledTask in schedule.Tasks)
        {
            var missed = GetMissed(scheduledTask);
            await executor.Invoke(scheduledTask.Url, missed);
            await scheduleStorage.UpdateTaskInvocation(scheduledTask);
        }
    }
    
    private DateTime? GetNextOccurence(Schedule schedule)
    {
        return schedule.Tasks.Min(GetNextOccurence);
    }
    private DateTime? GetNextOccurence(ScheduledTask task)
    {
        return CronExpression.Parse(task.CronExpression, CronFormat.IncludeSeconds).GetNextOccurrence(DateTime.UtcNow);
    }

    private IReadOnlyList<DateTime> GetMissed(ScheduledTask task)
    {
        return CronExpression.Parse(task.CronExpression, CronFormat.IncludeSeconds).GetOccurrences(task.LastInvocation, DateTime.UtcNow).ToList();
    }
}