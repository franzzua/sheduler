using System.ComponentModel.DataAnnotations.Schema;
using Sheduler.Contracts.Models;

namespace Sheduler.Storage.Database;

[Table("Schedules")]
public class ScheduleEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public static explicit operator ScheduleEntity(Schedule schedule)
    {
        return new ScheduleEntity
        {
            Description = schedule.Description,
            Id = schedule.Id,
            Name = schedule.Name,
        };
    }
    
    public static explicit operator Schedule(ScheduleEntity schedule)
    {
        var scheduledTasks = schedule.Tasks.Select(t => new ScheduledTask(
            t.Id, t.CronExpression, t.Url, t.LastInvocation)).ToList();
        return new Schedule(schedule.Id, schedule.Name, schedule.Description, scheduledTasks);
    }
    
    public virtual List<TaskEntity> Tasks { get; set; }
    public virtual InvokeEntity? Invoke { get; set; }
}