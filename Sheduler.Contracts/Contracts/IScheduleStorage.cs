using Sheduler.Contracts.Models;

namespace Sheduler.Contracts.Contracts;

public interface IScheduleStorage
{
    public Task CreateSchedule(Schedule schedule);
    
    public Task<Schedule?> Get(string scheduleId);
    public Task<IReadOnlyList<ScheduledTask>> GetReadyTasks(string id);
    
    public Task UpdateNextInvocation(Schedule schedule, TaskInvocation? taskInvocation);
    
    public Task<TaskInvocation?> GetNextInvocation(Schedule schedule);
    public Task Delete(string scheduleId);
    public Task<IList<Schedule>> GetAll();
    public Task UpdateTaskInvocation(ScheduledTask scheduledTask);
}
