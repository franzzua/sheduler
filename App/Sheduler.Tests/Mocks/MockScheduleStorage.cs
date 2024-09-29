using Sheduler.Contracts.Contracts;
using Sheduler.Contracts.Models;

namespace Sheduler.Tests.Mocks;

public class MockScheduleStorage : IScheduleStorage
{
    private readonly Dictionary<string, Schedule> _schedules = new();
    private readonly Dictionary<string, TaskInvocation> _invocations = new();
    
    public Task CreateSchedule(Schedule schedule)
    {
        _schedules.Add(schedule.Id, schedule);
        return Task.CompletedTask;
    }

    public async Task<IReadOnlyList<ScheduledTask>> GetReadyTasks(string id)
    {
        if (!_schedules.TryGetValue(id, out var schedule)) return [];
        return schedule.Tasks;
    }

    public async Task UpdateNextInvocation(Schedule schedule, TaskInvocation taskInvocation)
    {
        _invocations[schedule.Id] = taskInvocation;
    }

    public async Task<TaskInvocation?> GetNextInvocation(Schedule schedule)
    {
        return _invocations.GetValueOrDefault(schedule.Id);
    }

    public async Task Delete(string scheduleId)
    {
        _invocations.Remove(scheduleId);
    }

    public async Task<IList<Schedule>> GetAll()
    {
        return _schedules.Values.ToList();
    }

    public async Task UpdateTaskInvocation(ScheduledTask scheduledTask)
    {
    }

    public async Task<Schedule?> Get(string scheduleId)
    {
        return _schedules.GetValueOrDefault(scheduleId);
    }
}