using Sheduler.Contracts.Models;

namespace Sheduler.App;

public class ScheduleViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    
    public IList<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();

    public static implicit operator Schedule(ScheduleViewModel viewModel)
    {
        var tasks = viewModel.Tasks
            .Select(x => new ScheduledTask(x.Id, x.CronExpression, x.Uri, DateTime.UtcNow))
            .ToList();
        return new Schedule(viewModel.Id, viewModel.Name, viewModel.Description, tasks);
    }
    
    public static implicit operator ScheduleViewModel(Schedule viewModel)
    {
        var tasks = viewModel.Tasks
            .Select(x => new TaskViewModel
            {
                Id = x.Id,
                Uri = x.Url,
                CronExpression = x.CronExpression,
            })
            .ToList();
        return new ScheduleViewModel
        {
            Id = viewModel.Id,
            Name = viewModel.Name,
            Description = viewModel.Description,
            Tasks = tasks
        };
    }
}

public class TaskViewModel
{
    public string Id { get; set; }
    
    public string CronExpression { get; set; }
    
    public string Uri { get; set; }
}