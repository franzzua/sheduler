using Sheduler.Contracts.Models;

namespace Sheduler.App;

public class ScheduleViewModel
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    
    public IList<TaskViewModel> Tasks { get; init; } = new List<TaskViewModel>();

    public static implicit operator Schedule?(ScheduleViewModel? viewModel)
    {
        if (viewModel == null) return null;
        var tasks = viewModel.Tasks
            .Select(x => new ScheduledTask(x.Id, x.CronExpression, x.Uri, DateTime.UtcNow))
            .ToList();
        return new Schedule(viewModel.Id, viewModel.Name, viewModel.Description, tasks);
    }
    
    public static implicit operator ScheduleViewModel?(Schedule? model)
    {
        if (model == null) return null;
        var tasks = model.Tasks
            .Select(x => new TaskViewModel
            {
                Id = x.Id,
                Uri = x.Url,
                CronExpression = x.CronExpression,
            })
            .ToList();
        return new ScheduleViewModel
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Tasks = tasks
        };
    }
}

public class TaskViewModel
{
    public required string Id { get; init; }
    
    public required string CronExpression { get; init; }
    
    public required string Uri { get; init; }
}