using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Sheduler.Contracts.Contracts;
using Sheduler.Contracts.Models;
using Sheduler.Storage.Db;

namespace Sheduler.Storage;

public class ScheduleStorage(ScheduleContext context) : IScheduleStorage
{
    public async Task CreateSchedule(Schedule schedule)
    {
        await context.BulkInsertAsync([(ScheduleEntity)schedule]);
        var taskEntities = schedule.Tasks.Select(t => new TaskEntity
        {
            Id = t.Id,
            Url = t.Url,
            CronExpression = t.CronExpression,
            LastInvocation = t.LastInvocation,
            ScheduleId = schedule.Id
        });
        await context.BulkInsertAsync(taskEntities);
    }

    public async Task<Schedule?> Get(string scheduleId)
    {
        return (Schedule)await context.Schedules
            .Include(x => x.Tasks)
            .FirstAsync(x => x.Id == scheduleId);
    }

    public async Task<IReadOnlyList<ScheduledTask>> GetReadyTasks(string scheduleId)
    {
        var tasks = await context.Tasks.Where(x => x.ScheduleId == scheduleId).ToListAsync();
        var scheduledTasks = tasks.Select(t => new ScheduledTask(
            t.Id, t.CronExpression, t.Url, t.LastInvocation)).ToList();
        return scheduledTasks;
    }

    public async Task UpdateNextInvocation(Schedule schedule, TaskInvocation? taskInvocation)
    {
        await context.Invokes.Where(x => x.ScheduleId == schedule.Id).ExecuteDeleteAsync();
        if (taskInvocation != null)
        {
            await context.BulkInsertAsync([new InvokeEntity
            {
                Id = taskInvocation.Id,
                ScheduleId = schedule.Id,
                DateTime = taskInvocation.Time
            }]);
        }
    }

    public async Task<TaskInvocation?> GetNextInvocation(Schedule schedule)
    {
        return (TaskInvocation?) await context.Invokes.SingleOrDefaultAsync(x => x.ScheduleId == schedule.Id);
    }

    public async Task Delete(string scheduleId)
    {
        await context.Schedules.Where(x => x.Id == scheduleId).ExecuteDeleteAsync();
    }

    public async Task<IList<Schedule>> GetAll()
    {
        var entities = await context.Schedules
            .Include(x => x.Tasks)
            .ToListAsync();
        return entities.Select(x => (Schedule)x).ToList();
    }

    public async Task UpdateTaskInvocation(ScheduledTask scheduledTask)
    {
        await context.Tasks.Where(x => x.Id == scheduledTask.Id).ExecuteUpdateAsync(
            x => x.SetProperty(t => t.LastInvocation, DateTime.UtcNow)
        );
    }
}