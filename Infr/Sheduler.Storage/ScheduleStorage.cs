using Microsoft.EntityFrameworkCore;
using Sheduler.Contracts.Contracts;
using Sheduler.Contracts.Models;
using Sheduler.Storage.Database;

namespace Sheduler.Storage;

public class ScheduleStorage(string connectionString) : IScheduleStorage
{
    public async Task CreateSchedule(Schedule schedule)
    {
        await using var context = new ScheduleContext(connectionString);
        context.Add((ScheduleEntity)schedule);
        var taskEntities = schedule.Tasks.Select(t => new TaskEntity
        {
            Id = t.Id,
            Url = t.Url,
            CronExpression = t.CronExpression,
            LastInvocation = t.LastInvocation,
            ScheduleId = schedule.Id
        });
        context.AddRange(taskEntities);
        await context.SaveChangesAsync();
    }

    public async Task<Schedule?> Get(string scheduleId)
    {
        await using var context = new ScheduleContext(connectionString);
        return (Schedule)await context.Schedules
            .Include(x => x.Tasks)
            .FirstAsync(x => x.Id == scheduleId);
    }


    public async Task<IReadOnlyList<ScheduledTask>> GetReadyTasks(string scheduleId)
    {
        await using var context = new ScheduleContext(connectionString);
        var tasks = await context.Tasks.Where(x => x.ScheduleId == scheduleId).ToListAsync();
        var scheduledTasks = tasks.Select(t => new ScheduledTask(
            t.Id, t.CronExpression, t.Url, t.LastInvocation)).ToList();
        return scheduledTasks;
    }

    public async Task UpdateNextInvocation(Schedule schedule, TaskInvocation? taskInvocation)
    {
        await using var context = new ScheduleContext(connectionString);
        await context.Invokes.Where(x => x.ScheduleId == schedule.Id).ExecuteDeleteAsync();
        if (taskInvocation != null)
        {
            context.Add(new InvokeEntity
            {
                Id = taskInvocation.Id,
                ScheduleId = schedule.Id,
                DateTime = taskInvocation.Time
            });
            await context.SaveChangesAsync();
        }
    }

    public async Task<TaskInvocation?> GetNextInvocation(Schedule schedule)
    {
        await using var context = new ScheduleContext(connectionString);
        return (TaskInvocation?) await context.Invokes.SingleOrDefaultAsync(x => x.ScheduleId == schedule.Id);
    }

    public async Task Delete(string scheduleId)
    {
        await using var context = new ScheduleContext(connectionString);
        await context.Schedules.Where(x => x.Id == scheduleId).ExecuteDeleteAsync();
    }

    public async Task<IList<Schedule>> GetAll()
    {
        await using var context = new ScheduleContext(connectionString);
        return (await context.Schedules.ToListAsync()).Select(x => (Schedule)x).ToList();
    }

    public async Task UpdateTaskInvocation(ScheduledTask scheduledTask)
    {
        await using var context = new ScheduleContext(connectionString);
        await context.Tasks.Where(x => x.Id == scheduledTask.Id).ExecuteUpdateAsync(
            x => x.SetProperty(t => t.LastInvocation, DateTime.UtcNow)
        );
    }
}