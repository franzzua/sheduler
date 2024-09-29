using Sheduler.Contracts.Contracts;

namespace Sheduler.App;

public class AppService(
    IScheduleStorage scheduleStorage,
    ITaskService taskService
    )
{

    public async Task CreateSchedule(ScheduleViewModel schedule)
    {
        await scheduleStorage.CreateSchedule(schedule);
        await taskService.UpdateTask(schedule);
    }

    public async Task RunSchedule(string scheduleId)
    {
        var schedule = await scheduleStorage.Get(scheduleId);
        if (schedule == null) throw new Exception();
        await scheduleStorage.UpdateNextInvocation(schedule, null);
        await taskService.Run(schedule);
        await taskService.UpdateTask(schedule);
    }

    public async Task<ScheduleViewModel> Get(string id)
    {
        return await scheduleStorage.Get(id);
    }

    public async Task<IList<ScheduleViewModel>> GetAll()
    {
        return (await scheduleStorage.GetAll()).Select(x => new ScheduleViewModel
        {
            Description = x.Description,
            Id = x.Id,
            Name = x.Name,
            Tasks = []
        }).ToList();
    }
}